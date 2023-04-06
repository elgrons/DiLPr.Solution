const showModal = (name) => {
  [...document.querySelectorAll(`.modal`)].forEach((modalElement) => {
    modalElement.classList.add("obscured");
  });
  document.getElementById(`${name}-modal`).classList.remove("obscured");
};
const hideModal = (name) => {
  document.getElementById(`${name}-modal`).classList.add("obscured");
};

var cards = document.querySelectorAll(".card");

// Set the current card to the first one in the list
var currentCard = 0;
cards[currentCard].classList.add("current");

function animatecard(ev) {
  var t = ev.target;
  if (t.className === "but-nope") {
    t.parentNode.classList.add("nope");
  }
  if (t.className === "but-yay") {
    t.parentNode.classList.add("yes");
  }
}

document.body.addEventListener("click", animatecard);

function animationdone(ev) {
  var origin = ev.target.parentNode.parentNode;
  origin.classList.remove("nope");
  origin.classList.remove("yes");
  cards[currentCard].classList.remove("current");
  currentCard++;
  if (currentCard < cards.length) {
    cards[currentCard].classList.add("current");
  }
  else {
    location.reload();
  }
}

document.body.addEventListener(
  'animationend', animationdone
);
document.body.addEventListener("animationend", animationdone);
