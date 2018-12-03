const flightController = require('../controllers/flight');

module.exports = (app) => {
    app.get('/', flightController.index);

	app.get('/create', flightController.createGet);
	app.post('/create', flightController.createPost);

	app.get('/edit/:id', flightController.editGet);
	app.post('/edit/:id', flightController.editPost);

    app.get('/delete/:id', flightController.deleteGet);
    app.post('/delete/:id', flightController.deletePost);
};