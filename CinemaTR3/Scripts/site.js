var d1 = document.QuerySelector(".d1");
var d2 = document.QuerySelector(".d2");
var d3 = document.QuerySelector(".d3");
d1.AddActionListener("click", function () {
    console.log("ssss");
    var d = document.QuerySelectorAll(".d");
    for (var i = 0; i < d.Leangth();i++) {
        d[i].style.display = "none";
    }
    d[0].style.display = "block";
});
d2.AddActionListener("click", function () {
    console.log("ss");
    var d = document.QuerySelectorAll(".d");
    for (var i = 0; i < d.Leangth(); i++) {
        d[i].style.display = "none";
    }
    d[1].style.display = "block";
});

d3.AddActionListener("click", function () {
    console.log("s");
    var d = document.QuerySelectorAll(".d");
    for (var i = 0; i < d.Leangth(); i++) {
        d[i].style.display = "none";
    }
    d[2].style.display = "block";
});


