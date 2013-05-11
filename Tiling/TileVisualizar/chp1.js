function pageLoaded() {

    // Get a handle to the canvas object
    var canvas = document.getElementById('testcanvas');

    // Get the 2d context for this canvas
    var context = canvas.getContext('2d');

    // Our drawing code here. . .
    // Drawing complex shapes
    // Filled triangle
    context.beginPath();
    context.moveTo(10, 120); // Start drawing at 10,120
    context.lineTo(10, 180);
    context.lineTo(110, 150);
    context.fill(); // close the shape and fill it out
    // Stroked triangle
    context.beginPath();
    context.moveTo(140, 160); // Start drawing at 140,160
    context.lineTo(140, 220);
    context.lineTo(40, 190);
    context.closePath();
    context.stroke();
    // A more complex set of lines. . .
    context.beginPath();
    context.moveTo(160, 160); // Start drawing at 160,160
    context.lineTo(170, 220);
    context.lineTo(240, 210);
    context.lineTo(260, 170);
    context.lineTo(190, 140);
    context.closePath();
    context.stroke();
    // Drawing arcs
    // Drawing a semicircle
    context.beginPath();
    // Draw an arc at (400,50) with radius 40 from 0 to 180 degrees,anticlockwise
    context.arc(100, 300, 40, 0, Math.PI, true); //(PI radians = 180 degrees)
    context.stroke();
    // Drawing a full circle
    context.beginPath();
    // Draw an arc at (500,50) with radius 30 from 0 to 360 degrees,anticlockwise
    context.arc(100, 300, 30, 0, 2 * Math.PI, true); //(2*PI radians = 360 degrees)
    context.fill();
    // Drawing a three-quarter arc
    context.beginPath();
    // Draw an arc at (400,100) with radius 25 from 0 to 270 degrees,clockwise
    context.arc(200, 300, 25, 0, 3 / 2 * Math.PI, false); //(3/2*PI radians = 270 degrees) context.stroke();

    // Get a handle to the image object
    var image = new Image();
    image.src = 'spaceship.png';
    image.onload = function () {
    }
    // Draw the image at (0,350)
    context.drawImage(image, 0, 350);
    // Scaling the image to half the original size
    context.drawImage(image, 0, 400, 100, 25);
    // Drawing part of the image
    context.drawImage(image, 0, 0, 60, 50, 0, 420, 60, 50);


    //Translate origin to location of object
    context.translate(250, 370);
    //Rotate about the new origin by 60 degrees
    context.rotate(Math.PI/3);
    context.drawImage(image,0,0,60,50,-30,-25,60,50);
    //Restore to original state by rotating and translating back
    context.rotate(-Math.PI / 3);
    context.translate(-240, -370);
    //Translate origin to location of object
    context.translate(300, 370);
    //Rotate about the new origin
    context.rotate(3*Math.PI/4);
    context.drawImage(image,0,0,60,50,-30,-25,60,50);
    //Restore to original state by rotating and translating back
    context.rotate(-3*Math.PI/4);
    context.translate(-300, -370);

    
    // Image Loader
    var imageLoader = {
        loaded: true,
        loadedImages: 0,
        totalImages: 0,
        load: function (url) {
            this.totalImages++;
            this.loaded = false;
            var image = new Image();
            image.src = url;
            image.onload = function () {
                imageLoader.loadedImages++;
                if (imageLoader.loadedImages === imageLoader.totalImages) {
                    imageLoader.loaded = true;
                }
            }
            return image;
        }
    };



}