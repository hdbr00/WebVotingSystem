using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.MailKit.Core;

namespace ProyectoFinalPrograWeb.Controllers
{
    public class VotacionesController : Controller
    {
        public VotacionesController(IControlador controlador, UserManager<Usuario> userManager, IEmailService emailService)
        {
            _controlador = controlador;
            _userManager = userManager;
            _EmailService = emailService;
        }

        readonly IControlador _controlador;
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmailService _EmailService;

        public async Task<IActionResult> Index()
        {
            List<Candidato> candidatos;
            Usuario usuario = await _userManager.FindByIdAsync(_userManager.GetUserId(this.User));

            if (_controlador.Votacion.Buscar(m => m.Cedula == usuario.UserName) == null)
            {
                // No ha votado
                candidatos = _controlador.Candidato.Listar().ToList();
            }
            else {
                // Ya votó
                candidatos = new List<Candidato>();
            }
            return View(candidatos);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Votacion());
            }
            else
            {
                // Edit
                Votacion voto = _controlador.Votacion.Buscar(id.GetValueOrDefault());
                if (voto == null)
                {
                    return NotFound();
                }

                return View(voto);
            }

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Votacion votacion)
        {
            Usuario usuario = await _userManager.FindByIdAsync(_userManager.GetUserId(this.User));
            votacion.UsuarioId = usuario.Id;
            votacion.Cedula = usuario.UserName;
            votacion.Fecha = DateTime.Now;
            _controlador.Votacion.Agregar(votacion);

            _controlador.Guardar();
            _EmailService.SendAsync(usuario.Email, "Voto registrado", "Su voto fue registrado correctamente.");
            return RedirectToAction(nameof(Index));

            //return Ok();//View(votacion);
        }

        #region Api Methods

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var categoria = _controlador.Votacion.Buscar(id);

            if (categoria == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se borraba." });
            }

            _controlador.Votacion.Remover(categoria);
            _controlador.Guardar();

            return Json(new { success = true, message = "El registro se ha borrado permanentemente." });
        }

        [HttpPost]
        public IActionResult Listar()
        {
            int cantidadVotos = _controlador.Votacion.Listar().ToList().Count;

            return Json(new { data = cantidadVotos });
        }

        [HttpPost]
        public IActionResult CargarResultados()
        {
            List<Votacion> votaciones = _controlador.Votacion.Listar().ToList();
            List<Candidato> candidatos = _controlador.Candidato.Listar().ToList();
            Dictionary<int,dynamic> resultados = new Dictionary<int, dynamic>();
            //Array resultados = new String[5];
            //var resultados = new { };
            //Dictionary<int, String> resultados = new Dictionary<int, String>();
            //resultados.Add(0, "10");


            foreach (Candidato candidato in candidatos)
            {
                int cantidadVotos = (from votacion in votaciones
                                     where votacion.CandidatoId == candidato.IdCandidato
                                     select votacion).Count();
                resultados.Add(candidato.IdCandidato, new { idCandidato = candidato.IdCandidato, resultado = cantidadVotos });
            }

            return Json(resultados);
        }

        #endregion
    }
}