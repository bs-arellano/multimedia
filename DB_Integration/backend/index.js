const express = require('express')
const mongoose = require('mongoose');

const HighScore = require('./highscores')

const db_address = 'mongodb://localhost:27017/FlappyPlane'
mongoose.connect(db_address)
const db = mongoose.connection;

const app = express()
app.use(express.json());

app.get("/status", async (req, res) => {
    return res.status(200).json({ status: "ok" })
})

app.get("/top", async (req, res) => {
    try {
        const top = await HighScore.find().sort({ score: -1 }).limit(10);
        return res.status(200).json(top)
    }
    catch (e) {
        console.log(e)
        return res.status(500).json(e)
    }
})

app.post("/highscore", async (req, res) => {
    const { name, score } = req.body
    try {
        const newHighscore = new HighScore({ username: name, score: score, date: Date.now() })
        await newHighscore.save()
        return res.status(200)
    } catch (e) {
        console.log(e)
        return res.status(500).json(e)
    }
})

const server = app.listen(3000, () => {
    console.log('Listening on:', server.address());
});