const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    const Flight = sequelize.define("Flight", {
        departure: {type: Sequelize.TEXT,
            required: true,
            allowNull: false
        },
        destination: {
            type: Sequelize.TEXT,
            required: true,
            allowNull: false
        },
        status: {
            type: Sequelize.STRING,
            required: true,
            allowNull: false
        }
    }, {
        timestamps: false
    });

    return Flight;
};