const Flight = require('../models').Flight;

module.exports = {
    index: (req, res) => {
        Flight.findAll().then(flights => {
            res.render("flight/index", {flights: flights});
        })
    },

    createGet: (req, res) => {
        res.render("flight/create");
    },

    createPost: (req, res) => {
        let body = req.body.flight;

        Flight.create(body).then(() => {
            res.redirect("/");
        })
    },

    editGet: (req, res) => {
        let id = req.params.id;

        Flight.findById(id).then(flight => {
            res.render("flight/edit", {flight: flight})
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let body = req.body.flight;

        Flight.findById(id).then(flight => {
            flight.updateAttributes(body).then(() => {
                res.redirect("/");
            })
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;

        Flight.findById(id).then(flight => {
            res.render("flight/delete", {flight: flight})
        })
    },

    deletePost: (req, res) => {
        let id = req.params.id;

        Flight.findById(id).then(flight => {
            flight.destroy().then(() => {
                res.redirect("/");
            })
        })
    }
};