
document.addEventListener('DOMContentLoaded', () => {

  const navbarburger = document.getElementById('burger');
  const targetID = navbarburger.dataset.target;
  const target = document.getElementById(targetID);

  navbarburger.addEventListener('click', e => {
    navbarburger.classList.toggle('is-active');
    target.classList.toggle('is-active');
  });
});