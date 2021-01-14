//var restify = require('restify');


//var json2 = require('json2');
var mqtt = require('mqtt');
var client = mqtt.connect('mqtt://127.0.0.1');
var mysql = require('mysql');


// DB connection
var connection = mysql.createConnection({
    host : 'localhost',
    user : 'root',
    password : 'root',
    database : 'scooters'
});
connection.connect();


//----
// HTTP API
//----
/*
var server = restify.createServer();
server.use(restify.plugins.bodyParser());

server.get('/scooters', function(req, res, next) {
    res.send('List of scooters: [TODO]');
    return next();
});

server.get('/scooters/:id', function(req, res, next) {
    res.send('Current values for scooter ' + req.params['id'] + ': [TODO]');
    return next();
});

server.post('/scooters/:id', function(req, res, next) {
    res.send('Data received from scooter [TODO]');

    // uncomment to see posted data
    console.log(req.body);

    return next();
});

server.listen(8011, function() {
    console.log('%s listening at %s', server.name, server.url);
});
*/


//----
// MQTT PROTOCOL
//----

// CONNECT AND SUBSCRIBE
client.on('connect', function () {
    client.subscribe('scooters/#', function (err) {
        if (!err) {
            client.publish('serverStatus', 'Server Online')
            console.log('Server Online')
        }
    });
});

// READ MESSAGE
client.on('message', function (topic, message) {
    console.log(message.toString());

    var deserializedMessage = JSON.parse(message, function (key, value) {
        insertToDB(key, value, topic);
    });
    console.log(deserializedMessage);
});


// DB insert function
function insertToDB(key, value, id){
    if (key == "speed"){
        connection.query('INSERT INTO speed SET speed = ?, scooterId = ?' , [value, id]);
    }
    if (key == "battery"){
        connection.query('INSERT INTO battery SET battery = ?, scooterId = ?' , [value, id]);
    }
    if (key == "location"){
        connection.query('INSERT INTO location SET location = ?, scooterId = ?' , [value, id]);
    }
};