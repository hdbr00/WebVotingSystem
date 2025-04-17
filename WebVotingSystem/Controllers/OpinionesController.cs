using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebVotingSystem.Models;
using WebVotingSystem.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebVotingSystem.Controllers
{
    public class OpinionesController : Controller
    {
        public OpinionesController(IControlador controlador, UserManager<Usuario> userManager)
        {
            _controlador = controlador;
            _userManager = userManager;
        }

        readonly IControlador _controlador;
        private readonly UserManager<Usuario> _userManager;

        public IActionResult Index()
        {
            ViewBag.PublicacionesPropias = _controlador.Publicacion.Listar(m => m.UsuarioId == _userManager.GetUserId(User));
            return View(_controlador.Publicacion.Listar());
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Publicacion());
            }
            else
            {
                // Edit
                Publicacion publicacion = _controlador.Publicacion.Buscar(id.GetValueOrDefault());
                if (publicacion == null)
                {
                    return NotFound();
                }

                return View(publicacion);
            }
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                if (publicacion.IdPublicacion != 0)
                {
                    _controlador.Publicacion.Actualizar(publicacion);
                }
                else
                {
                    var id = _userManager.GetUserId(User);
                    publicacion.UsuarioId = id;
                    _controlador.Publicacion.Agregar(publicacion);
                }
                try
                {
                    _controlador.Guardar();
                    ViewData["ToastMensaje"] = "Publicado correctamente";
                    ViewData["ToastSuccess"] = "true";
                }
                catch (Exception)
                {
                    ViewData["ToastMensaje"] = "Falla al publicar";
                    ViewData["ToastSuccess"] = "false";
                }
                ViewBag.PublicacionesPropias = _controlador.Publicacion.Listar(m => m.UsuarioId == _userManager.GetUserId(User));
                return View("Index", _controlador.Publicacion.Listar());
                //return RedirectToAction(nameof(Index));
            }
            return View(publicacion);
        }

        #region Api Methods

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var categoria = _controlador.Publicacion.Buscar(id);

            if (categoria == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se borraba." });
            }

            _controlador.Publicacion.Remover(categoria);
            _controlador.Guardar();

            return Json(new { success = true, message = "El registro se ha borrado permanentemente." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { data = _controlador.Publicacion.Listar() });
        }

        [HttpPost]
        public IActionResult ListarPublicacionesPropias()
        {
            var id = _userManager.GetUserId(User);
            return Json(new { data = _controlador.Publicacion.Listar(
                m => m.UsuarioId == id)});
        }

        #endregion
    }
}