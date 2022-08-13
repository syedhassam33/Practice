using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models;
using System;

namespace PokemonAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public PokemonsController(PokemonDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpGet("pokemon")]
        public async Task<IActionResult> GetPokemon()
        {
            var result = await _context.Pokemons.ToListAsync();
     
            return Ok(result);
        } 


        [HttpGet("getpokemon/{id}")]

        public async Task<IActionResult> GetPokemonById(int id)
        {
            

            var result = await _context.Pokemons.FindAsync(id);
            if (result == null)
            {
                return BadRequest("Not Found");
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\syedh\Documents\Pokemon\Pokemon\wwwroot\images\" + result.Image);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                result.ImgByte = ms.ToArray();
            }

            return Ok(result);
        }

        //[HttpPost("createpokemon")]
        //public async Task<IActionResult> AddPokemon(Pokemon_Table entityPokemon)
        //{
        //    //string uniqueFileName = null;
        //    //if (entity.ImageStore != null)
        //    //{

        //    //    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
        //    //    uniqueFileName = Guid.NewGuid().ToString() + "_" + entity.ImageStore.FileName;
        //    //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    //    {
        //    //        entity.ImageStore.CopyTo(fileStream);
        //    //    }

        //    //    Pokemon_Table _entity = new Pokemon_Table
        //    //    {
        //    //        Name = entity.Name,
        //    //        Image = uniqueFileName,
        //    //        Description = entity.Description,
        //    //    };
        //    //    _context.Pokemons.Add(_entity);

        //    //}
        //    //Pokemon_Table entityPokemon = new Pokemon_Table
        //    //{
        //    //    Name = entity.Name,
        //    //    Image = uniqueFileName,
        //    //    Description = entity.Description,
        //    //};
        //    _context.Pokemons.Add(entityPokemon);
        //    await _context.SaveChangesAsync();
        //    return Ok(entityPokemon);
        //} 

        //[HttpPut("updatepokemon/{id}")]
        //public async Task<IActionResult> UpdatePokemon(int id, Pokemon_Table entity)
        //{
        //    var result = await _context.Pokemons.FindAsync(id);
        //    //string uniqueFileName = null;
        //    //if (result == null || result.Id == 0)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    //if (entity.ImageStore != null)
        //    //{
        //    //    var wwwroot = _environment.WebRootPath;
        //    //    if (!Directory.Exists(wwwroot))
        //    //    {
        //    //        Directory.CreateDirectory(wwwroot);
        //    //    }

        //    //    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
        //    //    uniqueFileName = Guid.NewGuid().ToString() + "_" + entity.ImageStore.FileName;
        //    //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    //    {
        //    //        entity.ImageStore.CopyTo(fileStream);
        //    //    }
        //    //    result.Image = uniqueFileName;
        //    //    _context.Pokemons.Update(result);
        //    //    await _context.SaveChangesAsync();
        //    //}
        //    // if(entity.Description != null && entity.Name != null)
        //    // {
        //    //     result.Name = entity.Name;
        //    //     //result.Image = uniqueFileName;
        //    //     result.Description = entity.Description;
        //    //     _context.Pokemons.Update(result);
        //    //     await _context.SaveChangesAsync();
        //    // }
        //    // else if(entity.Name == null && entity.Description != null )
        //    // {
        //    //    // result.Image = uniqueFileName;
        //    //     result.Description = entity.Description;
        //    //     _context.Pokemons.Update(result);
        //    //     await _context.SaveChangesAsync();
        //    // }
        //    // else if( entity.Description != null && entity.Name != null)
        //    // {
        //    //     result.Name = entity.Name;
        //    //     result.Description = entity.Description;
        //    //     _context.Pokemons.Update(result);
        //    //     await _context.SaveChangesAsync();
        //    // }
        //    //// && entity.ImageStore
        //    // else if(entity.Description == null && entity.Name != null)
        //    // {
        //    //     result.Name = entity.Name;
        //    //     //result.Image = uniqueFileName;
        //    //     _context.Pokemons.Update(result);
        //    //     await _context.SaveChangesAsync();
        //    // }else if(entity.Name != null) { result.Name = entity.Name; _context.Pokemons.Update(result); await _context.SaveChangesAsync(); }
        //    // else if(entity.Description != null) { result.Description = entity.Description; _context.Pokemons.Update(result); await _context.SaveChangesAsync(); }
        //    //result.Name = entity.Name;
        //    //result.Image = uniqueFileName;
        //    //result.Description = entity.Description;
        //    //_context.Pokemons.Update(result);
        //    //await _context.SaveChangesAsync();
        //    if (entity.Name != null && entity.Description != null)
        //    {
        //        result.Name = entity.Name;
        //        result.Description = entity.Description;
        //        _context.Pokemons.Update(result);
        //        await _context.SaveChangesAsync();
        //    }
        //   else if(entity.Name == null)
        //    {
        //        result.Description = entity.Description;
        //        _context.Pokemons.Update(result);
        //        await _context.SaveChangesAsync();
                
        //    }else if(entity.Description == null)
        //    {
        //        result.Name = entity.Name;
        //        _context.Pokemons.Update(result);
        //        await _context.SaveChangesAsync();
        //    }
           
        //    return Ok();
        //}

        [HttpDelete("deletepokemon/{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var result = await _context.Pokemons.FindAsync(id);
            Console.WriteLine(result);
            if( result == null)
            {
                return BadRequest("Nothing to delete");
            }

            _context.Pokemons.Remove(result);
             await _context.SaveChangesAsync();
            return Ok(await _context.Pokemons.ToListAsync());
        }

        [HttpPost("createpokemon")]
        public async Task<IActionResult> createPokemon([FromForm] Pokemon_Table oImg)
        {
            string message = "";
            var files = oImg.Files;
            string uniqueFileName = null;

            if (files != null && files.Length > 0)
            {
                string path = _environment.WebRootPath + "\\images\\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + oImg.Files.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if(System.IO.File.Exists(path + uniqueFileName))
                {
                    System.IO.File.Delete(path + uniqueFileName);
                }
                using(FileStream fileStream = System.IO.File.Create(path + uniqueFileName))
                {
                    files.CopyToAsync(fileStream);
                    fileStream.FlushAsync();
                    message = "Success";
                }

            }
            Pokemon_Table entityPokemon = new Pokemon_Table
            {
                Name = oImg.Name,
                Image = uniqueFileName,
                Description = oImg.Description,
            };
            _context.Pokemons.Add(entityPokemon);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("updatepokemon/{id}")]
        public async Task<IActionResult> updatePokemon(int id,[FromForm] Pokemon_Table entity)
        {
            var result = await _context.Pokemons.FindAsync(id);

            var files = entity.Files;
            string uniqueFileName = null;

            if (files != null && files.Length > 0)
            {
                string path = _environment.WebRootPath + "\\images\\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + entity.Files.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (System.IO.File.Exists(path + uniqueFileName))
                {
                    System.IO.File.Delete(path + uniqueFileName);
                }
                using (FileStream fileStream = System.IO.File.Create(path + uniqueFileName))
                {
                    files.CopyToAsync(fileStream);
                    fileStream.FlushAsync(); 
                }

            }
            if (entity.Name != null && entity.Description != null && entity.Files != null)
            {
                result.Name = entity.Name;
                result.Description = entity.Description;
                result.Image = uniqueFileName;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            }
            else if (entity.Name == null && entity.Description != null && entity.Files != null)
            {
                result.Description = entity.Description;
                result.Image = uniqueFileName;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();

            }
            else if (entity.Description == null && entity.Name != null && entity.Files != null)
            {
                result.Name = entity.Name;
                result.Image = uniqueFileName;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            } 
            else if( entity.Files == null && entity.Name != null && entity.Description != null)
            {
                result.Name = entity.Name;
                result.Description = entity.Description;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            }
            else if(entity.Files != null && entity.Name == null && entity.Description == null)
            {
                result.Image = uniqueFileName;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            }
            else if (entity.Name != null && entity.Files == null && entity.Description == null)
            {
                result.Name = entity.Name;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            }
            else if (entity.Description != null && entity.Name == null && entity.Files == null)
            {
                result.Description = entity.Description;
                _context.Pokemons.Update(result);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
