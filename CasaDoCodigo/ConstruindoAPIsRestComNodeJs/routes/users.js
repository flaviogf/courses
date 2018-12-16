module.exports = (app) => {
    const Users = app.db.models.Users;

    app.route('/user')
        .all(app.auth.authenticate())
        /**
            @api {get} /users Exibi usuario autenticado
            @apiGroup Usuarios
            @apiHeader (200) {String} Authorization Token do usuario
            @apiHeaderExample {json} Request-Example:
                {
                    "Authorization" : "JWT abc.def.ghi.jklm"
                }
            @apiSuccess (200) {Number} id Id do usuario
            @apiSuccess (200) {String} name Nome do usuario
            @apiSuccess (200) {String} email Email do usuario
            @apiSuccessExample {json} Success-Response:
                HTTP/1.1 200 OK
                {
                    "id": 1,
                    "name": "John Connor",
                    "email": "john@connor.net"
                }
         */
        .get((req, res) => {
            Users.findOne(req.user.id, {
                attributes: ['id', 'name', 'email']
            })
                .then((result) => res.json(result))
                .catch((error) => res.status(401).json(error));
        })
        .delete((req, res) => {
            Users.destroy({ where: req.users.id })
                .then((result) => res.sendStatus(204))
                .catch((error) => res.status(401).json(error));
        });

    /**
        @api {post} /users Cadastra novo usuario
        @apiGroup Usuarios
        @apiParamExample  {json} Request-Example:
            {
                "name": "flavio",
                "email": "flavio@email.com",
                "password": "123456"
            }
        @apiSuccess (200) {Number} id Id do usuario
        @apiSuccess (200) {String} name Nome do usuario
        @apiSuccess (200) {String} email Email do usuario
        @apiSuccess (200) {Date} updated_at Data de atualização
        @apiSuccess (200) {Date} created_at Data de cadastro
        @apiSuccessExample {json} Success-Response:
            {
                "id": 1,
                "name": "Flavio",
                "email": "flavio@email.com",
                "password": "123456",
                "updated_at": "2015-09-09",
                "created_at": "2015-09-09"
            }
        @apiErrorExample {json} Error-Response:
            HTTP/1.1 412 Precondition Failed
    */
    app.post('/users', (req, res) => {
        Users.create(req.body)
            .then((result) => res.json(result))
            .catch((error) => res.status(401).json(error));
    });
}