const images = {
    src1: "../img/large-cylinder-block.png",
    src2: "../img/large-metal-piston.png",
    src3: "../img/metal-frame.png",
    src4: "../img/transparent-plate.png",
    src5: "../img/piston-displacement-lever.png",
    src6: "../img/pressure-gauge.png",
    src7: "../img/oil-container.png",
    src8: "../img/small-cylinder-block.png",
    src9: "../img/small-metal-piston.png",
    src10: "../img/intake-valve.png",
    src11: "../img/intake-valve.png",
    src12: "../img/pressure-relief-unit.png",
    src13: "../img/platform.png",
}
list.onclick = function (event)
{
    document.getElementsByClassName("device-map-elements")[0].innerHTML = '<img style="width: 500px;height:480px" src="'+images[event.target.id] +'"/>'
}