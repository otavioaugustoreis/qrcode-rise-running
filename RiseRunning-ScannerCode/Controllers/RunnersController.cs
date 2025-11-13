using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RiseRunning_ScannerCode.Commons;
using RiseRunning_ScannerCode.Entity;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RiseRunning_ScannerCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunnersController(IMemoryCache memoryCache) : ControllerBase
    {   

        private readonly ConcurrentQueue<RunnerEntity> _runners = new();
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string CacheKey = "RunnersQueue";


        [HttpPost]
        public async Task<IActionResult> PostRunner([FromHeader] string nome, [FromHeader] string cpf)
        {
            if (!ValidateCPF.IsCpf(cpf)) 
                     Ok(MessageCommons.RunnerCpf);
           
                foreach (var item in _runners)
                {
                    if (item.Cpf == ValidateCPF.cpfToLong(cpf))
                    {
                        return Ok(MessageCommons.RunnerJaRegistrado(item.Nome));
                    }
                }

                var runner = new RunnerEntity
            {
                Nome = nome,
                Cpf = ValidateCPF.cpfToLong(cpf)
            };

            _runners.Enqueue(runner);

            _memoryCache.Set(CacheKey, _runners, TimeSpan.FromMinutes(30));

            return Ok(MessageCommons.RunnerRegistrado(runner.Nome));
        }

        [HttpGet]
        public ActionResult<List<RunnerEntity>> GetAllRunner() 
        {
            //if (_memoryCache.TryGetValue(CacheKey, out ConcurrentQueue<RunnerEntity> runners))
            //{
            //    return runners!
            //        .OrderByDescending(p => p.DataHora)
            //        .ToList();
            //}

            return _runners
                .OrderByDescending(p => p.DataHora)
                .ToList();
        }
    }
}
