using Microsoft.AspNetCore.Mvc;
using WebVotingSystem.Models;
using WebVotingSystem.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebVotingSystem.Controllers
{
    public class CandidatosController : Controller
    {
        public CandidatosController(IControlador controlador, IWebHostEnvironment webHostEnvironment)
        {
            _controlador = controlador;
            _webHostEnvironment = webHostEnvironment;
        }

        readonly IControlador _controlador;
        readonly IWebHostEnvironment _webHostEnvironment;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Candidato());
            }
            else
            {
                // Edit
                Candidato candididato = _controlador.Candidato.Buscar(id.GetValueOrDefault());
                if (candididato == null)
                {
                    return NotFound();
                }

                return View(candididato);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                string rutaRaiz = _webHostEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivos.Count > 0)
                {
                    var rutaImagenes = Path.Combine(rutaRaiz, @"imagenes\candidatos");

                    string nombreArchivo = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(archivos[0].FileName);

                    // Borra la imagen, si existe alguna
                    if (!string.IsNullOrEmpty(candidato.FotoUrl))
                    {
                        var imagen = Path.Combine(rutaRaiz, candidato.FotoUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagen))
                        {
                            System.IO.File.Delete(imagen);
                        }
                    }

                    if (!Directory.Exists(rutaImagenes))
                    {
                        Directory.CreateDirectory(rutaImagenes);
                    }

                    // Carga el archivo en el servidor
                    using (var stream = new FileStream(Path.Combine(rutaImagenes, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(stream);
                    }

                    candidato.FotoUrl = Path.Combine(@"\imagenes\candidatos", nombreArchivo + extension);
                }
                if (candidato.IdCandidato != 0)
                {
                    _controlador.Candidato.Actualizar(candidato);
                }
                else
                {
                    _controlador.Candidato.Agregar(candidato);
                }
                _controlador.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(candidato);
        }

        #region Api Methods

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var categoria = _controlador.Candidato.Buscar(id);

            if (categoria == null)
            {
                return Json(new { success = false, message = "Se ha producido un error mientras se borraba." });
            }

            _controlador.Candidato.Remover(categoria);
            _controlador.Guardar();

            return Json(new { success = true, message = "El registro se ha borrado permanentemente." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { data = _controlador.Candidato.Listar() });
        }

        #endregion
    }
}