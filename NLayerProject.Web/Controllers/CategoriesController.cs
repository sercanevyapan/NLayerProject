using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Service;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categorieService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categorieService, IMapper mapper)
        {

            _categorieService = categorieService;
            _mapper = mapper;
        }

        public async Task<IActionResult>  Index()
        {
            var categories = await _categorieService.GetAllAsync();


            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categorieService.AddAsync(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categorieService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categorieService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var category = _categorieService.GetByIdAsync(id).Result;

            _categorieService.Remove(category);

            return RedirectToAction("Index");


        }

    }
}
