
//////filter2
////document.addEventListener('DOMContentLoaded', function () {
////    // Get the filter value from the query parameter
////    const urlParams = new URLSearchParams(window.location.search);
////    const filter = urlParams.get('filter');

////    // Default to 'all' if no filter is set
////    if (!filter) {
////        filter = '*'; // Assuming '*' is the 'All' filter
////    }

////    // Handle the filter buttons' state
////    const filterButtons = document.querySelectorAll('.filter-button-group button');
////    filterButtons.forEach(button => {
////        button.classList.remove('active-filter-btn');
////        if (filter === '*' && button.getAttribute('data-filter') === '*') {
////            // Activate only the 'All' button
////            button.classList.add('active-filter-btn');
////        } else if (button.getAttribute('data-filter') === .${ filter }) {
////        // Activate the corresponding category button
////        button.classList.add('active-filter-btn');
////    }
////});

////// Handle the visibility of items
////const filterItems = document.querySelectorAll('.collection-list .col-12');
////filterItems.forEach(item => {
////    if (filter === '*' || item.classList.contains(filter)) {
////        item.style.display = 'block';
////    } else {
////        item.style.display = 'none';
////    }
////});
////});
////document.getElementById('category-select').addEventListener('change', function () {
////    const selectedCategory = this.value;
////    window.location.href = /Book?filter=${encodeURIComponent(selectedCategory)};
////});

//////kalpleme
////document.addEventListener('DOMContentLoaded', function () {
////    // Tüm kalp simgelerini seç
////    const heartIcons = document.querySelectorAll('.heart-icon');

////    heartIcons.forEach(heartIcon => {
////        heartIcon.addEventListener('click', function () {
////            var icon = this.querySelector('i');
////            // Toggle color between red and original
////            if (icon.style.color === 'red') {
////                icon.style.color = ''; // Remove color
////            } else {
////                icon.style.color = 'red'; // Set color to red
////            }
////        });
////    });
////});




//////rating verme
////document.addEventListener('DOMContentLoaded', function () {
////    // Tüm kitap kartlarını seç
////    const cardShops = document.querySelectorAll('.card-shop');

////    // Her bir kitap kartını işleme
////    cardShops.forEach(cardShop => {
////        const stars = cardShop.querySelectorAll('.star');

////        stars.forEach((star, index) => {
////            star.addEventListener('click', () => {
////                // Tüm yıldızların selected sınıfını kaldır
////                stars.forEach(s => s.classList.remove('selected'));

////                // Tıklanan yıldız ve öncekilerin sınıfını ekle
////                for (let i = 0; i <= index; i++) {
////                    stars[i].classList.add('selected');
////                }
////            });
////        });
////    });
////});


////$(document).ready(function () {
////    $('.book-slider__container').owlCarousel({
////        loop: true,
////        margin: 10,
////        nav: true,
////        responsive: {
////            0: {
////                items: 1
////            },
////            600: {
////                items: 2
////            },
////            1000: {
////                items: 3
////            }
////        }
////    });
////});


//////   slider index

////document.addEventListener('DOMContentLoaded', function () {
////    // Carousel ayarları
////    const sliders = ['bestSellers', 'newReleases', 'genres'];

////    sliders.forEach(id => {
////        const slider = document.getElementById(id);

////        if (slider) {
////            const carousel = new bootstrap.Carousel(slider, {
////                interval: 5000,
////                ride: 'carousel'
////            });
////        }
////    });
////});


//////  slider index end



////// filter

////document.addEventListener('DOMContentLoaded', function () {
////    // Get the filter value from the query parameter
////    const urlParams = new URLSearchParams(window.location.search);
////    const filter = urlParams.get('filter');

////    // Default to 'all' if no filter is set
////    if (!filter) {
////        filter = '*'; // Assuming '*' is the 'All' filter
////    }

////    // Handle the filter buttons' state
////    const filterButtons = document.querySelectorAll('.filter-button-group button');
////    filterButtons.forEach(button => {
////        button.classList.remove('active-filter-btn');
////        if (filter === '*' && button.getAttribute('data-filter') === '*') {
////            // Activate only the 'All' button
////            button.classList.add('active-filter-btn');
////        } else if (button.getAttribute('data-filter') === `.${filter}`) {
////            // Activate the corresponding category button
////            button.classList.add('active-filter-btn');
////        }
////    });

////    // Handle the visibility of items
////    const filterItems = document.querySelectorAll('.collection-list .col-12');
////    filterItems.forEach(item => {
////        if (filter === '*' || item.classList.contains(filter)) {
////            item.style.display = 'block';
////        } else {
////            item.style.display = 'none';
////        }
////    });
////});
////document.getElementById('category-select').addEventListener('change', function () {
////    const selectedCategory = this.value;
////    window.location.href = `/Book?filter=${encodeURIComponent(selectedCategory)}`;
////});

