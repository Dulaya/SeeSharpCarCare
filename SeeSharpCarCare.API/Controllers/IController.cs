using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IController<T>
{
    Task<ActionResult<string>> AddController(T obj);

}