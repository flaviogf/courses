module.exports = (app) => {
    /**
     * @api {get} / API STATUS
     * @apiGroup Status
     * @apiSuccess (200) {String} status Mensagem de status
     * @apiSuccessExample {json} Sucesso:
         HTTP/1.1 200 OK
         { "status": "NTask API" }
     */
    app.get('/', (req, res) => {
        res.json({ status: 'Ntask API' });
    });
}