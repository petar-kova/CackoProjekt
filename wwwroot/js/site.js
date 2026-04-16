const header = document.getElementById('site-header');
if (header) {
  window.addEventListener('scroll', () => {
    header.classList.toggle('scrolled', window.scrollY > 12);
  });
}

const menuBtn = document.getElementById('menu-toggle');
const mainNav = document.getElementById('main-nav');
if (menuBtn && mainNav) {
  menuBtn.addEventListener('click', () => {
    const open = mainNav.classList.toggle('open');
    menuBtn.setAttribute('aria-expanded', open ? 'true' : 'false');
  });
}

const filterButtons = document.querySelectorAll('.filter-btn');
const productCards = document.querySelectorAll('.product-card');
filterButtons.forEach(btn => {
  btn.addEventListener('click', () => {
    filterButtons.forEach(x => x.classList.remove('active'));
    btn.classList.add('active');

    const filter = btn.dataset.filter;
    productCards.forEach(card => {
      const visible = filter === 'all' || card.dataset.category === filter;
      card.style.display = visible ? 'block' : 'none';
    });
  });
});

const revealObserver = new IntersectionObserver((entries) => {
  entries.forEach(entry => {
    if (entry.isIntersecting) {
      entry.target.classList.add('visible');
    }
  });
}, { threshold: 0.15 });

document.querySelectorAll('.reveal').forEach(el => revealObserver.observe(el));

const counters = document.querySelectorAll('[data-count]');
const countObserver = new IntersectionObserver((entries) => {
  entries.forEach(entry => {
    if (!entry.isIntersecting || entry.target.dataset.done) return;

    const target = Number(entry.target.dataset.count);
    let val = 0;
    const step = Math.max(1, Math.ceil(target / 60));
    const timer = setInterval(() => {
      val += step;
      if (val >= target) {
        entry.target.textContent = target;
        clearInterval(timer);
      } else {
        entry.target.textContent = val;
      }
    }, 25);

    entry.target.dataset.done = '1';
  });
}, { threshold: 0.7 });

counters.forEach(c => countObserver.observe(c));

const testimonials = document.querySelectorAll('.testimonial');
if (testimonials.length) {
  let index = 0;
  setInterval(() => {
    testimonials[index].classList.remove('active');
    index = (index + 1) % testimonials.length;
    testimonials[index].classList.add('active');
  }, 4500);
}

const lightbox = document.getElementById('lightbox');
const lightboxImg = document.getElementById('lightbox-img');
const closeLightbox = document.getElementById('close-lightbox');

const lightboxOpeners = [...document.querySelectorAll('.gallery-item'), ...document.querySelectorAll('.open-lightbox')];
lightboxOpeners.forEach(el => {
  el.addEventListener('click', () => {
    if (!lightbox || !lightboxImg) return;
    const image = el.closest('.product-card')?.querySelector('img') || el;
    lightboxImg.src = image.src;
    lightbox.classList.add('open');
    lightbox.setAttribute('aria-hidden', 'false');
  });
});

if (closeLightbox && lightbox) {
  closeLightbox.addEventListener('click', () => {
    lightbox.classList.remove('open');
    lightbox.setAttribute('aria-hidden', 'true');
  });

  lightbox.addEventListener('click', (e) => {
    if (e.target === lightbox) closeLightbox.click();
  });
}

const cookieBanner = document.getElementById('cookie-banner');
const acceptCookies = document.getElementById('accept-cookies');
if (cookieBanner && localStorage.getItem('cookieConsent') === '1') {
  cookieBanner.classList.add('hidden');
}
if (cookieBanner && acceptCookies) {
  acceptCookies.addEventListener('click', () => {
    localStorage.setItem('cookieConsent', '1');
    cookieBanner.classList.add('hidden');
  });
}
