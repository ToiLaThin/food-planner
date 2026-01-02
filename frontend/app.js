// $(document).ready(function() {
//     $(".topnav a").on("click", function(event) {
//         $(".topnav a").removeClass("active");
//         let element = $(this);
//         element.toggleClass("active");
//         if (element.text().toLowerCase() == "listing") {
//             $.ajax({
//                 url: "http://localhost:5295/api/v1/foods",
//             })
//             .done(function(data) {
//                 debugger;
//                 console.log(data);
//                 $("#listing").show();
//                 $("#planner").hide();
//             })

//         }
//         else {
//             $("#listing").hide();
//             $("#planner").show();
//         }
//     });

// })


function refreshFoods(foods) {
    let container = $("#listing");
    container.empty();
    for (let food of foods) {
        let item = `<p>${food.name}</p>`;
        container.append(item);
    }
}
$.ajax({ url: "http://localhost:5295/api/v1/foods" })
    .done(function(data) {
        refreshFoods(data);
        $("#listing").show();
        $("#planner").hide();
    });