using AutoMapper;
using FundWise.Domain.Entities;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class UsersController : Controller
{

    private readonly IUserService _service;
    private readonly IMapper mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _service = userService;
        this.mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _service.RetrieveAllAsync();
        return View(users);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var dto = await _service.RemoveByIdAsync(id);
        return View(dto);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(User entity)
    {
        var dto = mapper.Map<UserCreationDto>(entity);
        await _service.AddAsync(dto);
        return RedirectToAction("Index");
    }

    public IActionResult Update()
    {
        return View();
    }
    [HttpPut]
    public async Task<IActionResult> Update(User entity)
    {
        var dto = mapper.Map<UserUpdateDto>(entity);
        await _service.ModifyAsync(dto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromQuery]long id)
    {
        await _service.RemoveByIdAsync(id);
        return RedirectToAction("Index");
    }
}
