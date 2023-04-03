const showModal = name => {
  [...document.querySelectorAll(`.modal`)].forEach(modalElement => {
    modalElement.classList.add('obscured');
  });
  document.getElementById(`${name}-modal`).classList.remove('obscured');
}
const hideModal = name => {
  document.getElementById(`${name}-modal`).classList.add('obscured');
}