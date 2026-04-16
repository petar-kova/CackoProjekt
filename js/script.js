window.addEventListener('load', () => {
  const loader = document.getElementById('loader');
  loader.style.opacity = '0';
  setTimeout(() => loader.remove(), 300);
});

const header = document.getElementById('site-header');
window.addEventListener('scroll', () => {
  header.classList.toggle('scrolled', window.scrollY > 10);
});

const menuBtn = document.getElementById('menu-toggle');
const nav = document.getElementById('main-nav');
menuBtn.addEventListener('click', () => {
  const isOpen = nav.classList.toggle('open');
  menuBtn.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
});

const filterButtons = document.querySelectorAll('.filter-btn');
const products = document.querySelectorAll('.product-card');
filterButtons.forEach(btn => {
  btn.addEventListener('click', () => {
    filterButtons.forEach(b => b.classList.remove('active'));
    btn.classList.add('active');
    const filter = btn.dataset.filter;

    products.forEach(product => {
      const match = filter === 'all' || product.dataset.category === filter;
      product.style.display = match ? 'block' : 'none';
    });
  });
});

const observer = new IntersectionObserver(entries => {
  entries.forEach(entry => {
    if (entry.isIntersecting) entry.target.classList.add('visible');
  });
}, { threshold: 0.15 });
document.querySelectorAll('.reveal').forEach(el => observer.observe(el));

const counters = document.querySelectorAll('[data-count]');
const animateCounter = (el) => {
  const target = Number(el.dataset.count);
  let count = 0;
  const inc = Math.max(1, Math.ceil(target / 60));
  const interval = setInterval(() => {
    count += inc;
    if (count >= target) {
      el.textContent = target;
      clearInterval(interval);
    } else {
      el.textContent = count;
    }
  }, 25);
};

const counterObserver = new IntersectionObserver(entries => {
  entries.forEach(entry => {
    if (entry.isIntersecting && !entry.target.dataset.done) {
      animateCounter(entry.target);
      entry.target.dataset.done = '1';
    }
  });
}, { threshold: 0.8 });
counters.forEach(counter => counterObserver.observe(counter));

const testimonials = document.querySelectorAll('.testimonial');
let current = 0;
setInterval(() => {
  testimonials[current].classList.remove('active');
  current = (current + 1) % testimonials.length;
  testimonials[current].classList.add('active');
}, 4500);

const lightbox = document.getElementById('lightbox');
const lightboxImg = document.getElementById('lightbox-img');
const closeLightbox = document.getElementById('close-lightbox');

const openers = [...document.querySelectorAll('.gallery-item'), ...document.querySelectorAll('.open-lightbox')];
openers.forEach(el => {
  el.addEventListener('click', () => {
    const img = el.closest('.product-card')?.querySelector('img') || el;
    lightboxImg.src = img.src;
    lightbox.classList.add('open');
    lightbox.setAttribute('aria-hidden', 'false');
  });
});

closeLightbox.addEventListener('click', () => {
  lightbox.classList.remove('open');
  lightbox.setAttribute('aria-hidden', 'true');
});

lightbox.addEventListener('click', (e) => {
  if (e.target === lightbox) closeLightbox.click();
});

const cookieBanner = document.getElementById('cookie-banner');
const acceptCookies = document.getElementById('accept-cookies');
if (localStorage.getItem('cookieConsent')) {
  cookieBanner.classList.add('hidden');
}
acceptCookies.addEventListener('click', () => {
  localStorage.setItem('cookieConsent', '1');
  cookieBanner.classList.add('hidden');
});

const hero = document.querySelector('.hero');
window.addEventListener('scroll', () => {
  const offset = window.scrollY * 0.35;
  hero.style.backgroundPositionY = `${-offset}px`;
});
