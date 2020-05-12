using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLink.Models;

namespace MusicLink.Controllers
{
    public class PodcastEpisodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PodcastEpisodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PodcastEpisodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PodcastEpisodes.Include(p => p.podcast);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PodcastEpisodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastEpisode = await _context.PodcastEpisodes
                .Include(p => p.podcast)
                .FirstOrDefaultAsync(m => m.EpisodeID == id);
            if (podcastEpisode == null)
            {
                return NotFound();
            }

            return View(podcastEpisode);
        }

        // GET: PodcastEpisodes/Create
        public IActionResult Create()
        {
            ViewData["PodcastID"] = new SelectList(_context.Podcasts, "PodcastID", "PodcastID");
            return View();
        }

        // POST: PodcastEpisodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpisodeID,Title,Season,Episode,Description,PodcastDate,Genre,Link,Image,Language,Authors,Explicit,PodcastID")] PodcastEpisode podcastEpisode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastEpisode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PodcastID"] = new SelectList(_context.Podcasts, "PodcastID", "PodcastID", podcastEpisode.PodcastID);
            return View(podcastEpisode);
        }

        // GET: PodcastEpisodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastEpisode = await _context.PodcastEpisodes.FindAsync(id);
            if (podcastEpisode == null)
            {
                return NotFound();
            }
            ViewData["PodcastID"] = new SelectList(_context.Podcasts, "PodcastID", "PodcastID", podcastEpisode.PodcastID);
            return View(podcastEpisode);
        }

        // POST: PodcastEpisodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpisodeID,Title,Season,Episode,Description,PodcastDate,Genre,Link,Image,Language,Authors,Explicit,PodcastID")] PodcastEpisode podcastEpisode)
        {
            if (id != podcastEpisode.EpisodeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastEpisode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastEpisodeExists(podcastEpisode.EpisodeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PodcastID"] = new SelectList(_context.Podcasts, "PodcastID", "PodcastID", podcastEpisode.PodcastID);
            return View(podcastEpisode);
        }

        // GET: PodcastEpisodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastEpisode = await _context.PodcastEpisodes
                .Include(p => p.podcast)
                .FirstOrDefaultAsync(m => m.EpisodeID == id);
            if (podcastEpisode == null)
            {
                return NotFound();
            }

            return View(podcastEpisode);
        }

        // POST: PodcastEpisodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podcastEpisode = await _context.PodcastEpisodes.FindAsync(id);
            _context.PodcastEpisodes.Remove(podcastEpisode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastEpisodeExists(int id)
        {
            return _context.PodcastEpisodes.Any(e => e.EpisodeID == id);
        }
    }
}
