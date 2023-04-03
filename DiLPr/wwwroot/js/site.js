const showModal = name => {
  [...document.querySelectorAll(`.modal`)].forEach(modalElement => {
    modalElement.classList.add('obscured');
  });
  document.getElementById(`${name}-modal`).classList.remove('obscured');
}
const hideModal = name => {
  document.getElementById(`${name}-modal`).classList.add('obscured');
}

var cards = document.querySelectorAll('.card');

// Set the current card to the first one in the list
var currentCard = 0;
cards[currentCard].classList.add('current');

function animatecard(ev) {
  var t = ev.target;
  if (t.className === 'but-nope') {
    t.parentNode.classList.add('nope');
  }
  if (t.className === 'but-yay') {
    t.parentNode.classList.add('yes');

    // If the "yay" button is clicked, transition to the next card
    cards[currentCard].classList.remove('current');
    currentCard++;
    if (currentCard < cards.length) {
      cards[currentCard].classList.add('current');
    } else {
      // If there are no more cards, do something else (e.g. display a message)
    }
  }
}

document.body.addEventListener('click', animatecard);

function animationdone(ev) {
  // get the container
  var origin = ev.target.parentNode;

  // remove the appropriate class
  // depending on the animation name
  if (ev.animationName === 'yay') {
    // Only remove the card if the "yay" button was clicked
    if (ev.target.classList.contains('but-yay')) {
      origin.classList.remove('yes');
    }
  }
  if (ev.animationName === 'nope') {
    origin.classList.remove('nope');
  }
}

document.body.addEventListener('animationend', animationdone);