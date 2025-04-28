using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022330067.Models;
using System.Collections.Generic;
using tpmodul10_103022330067;
namespace tpmodul10_103022330067.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MMahasiswaControl : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Intan Nur Aini", Nim = "103022330067" },
            new Mahasiswa { Nama = "⁠I Gede Agung Peramerta", Nim = "103022330117" },
            new Mahasiswa { Nama = "Fadhli Rabbi", Nim = "103022300055" },
            new Mahasiswa { Nama = "Steven Gerald", Nim = "103022300155" },
            new Mahasiswa { Nama = "Muhammad iqbal Al Khaththath", Nim = "103022300146" },
            new Mahasiswa { Nama = "Raihan Ananda Putra", Nim = "103022330075" },
            new Mahasiswa { Nama = "Gumilar Hari Subagja", Nim = "103022300137" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(mahasiswaList);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Index tidak ditemukan.");

            return Ok(mahasiswaList[index]);
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            mahasiswaList.Add(newMahasiswa);
            return Ok("Mahasiswa berhasil ditambahkan.");
        }

        [HttpPut("{index}")]
        public ActionResult UpdateMahasiswa(int index, [FromBody] Mahasiswa updatedMahasiswa)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Index tidak ditemukan.");

            mahasiswaList[index].Nama = updatedMahasiswa.Nama;
            mahasiswaList[index].Nim = updatedMahasiswa.Nim;

            return Ok("Mahasiswa berhasil diupdate.");
        }


        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Index tidak ditemukan.");

            mahasiswaList.RemoveAt(index);
            return Ok("Mahasiswa berhasil dihapus.");
        }
    }
}
