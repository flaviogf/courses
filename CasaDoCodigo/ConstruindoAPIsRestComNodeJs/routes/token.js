import jwt from 'jwt-simple';

module.exports = (app) => {
    const config = app.libs.config;
    const Users = app.db.models.Users;

    /**
     * @api {post} /token Token autenticado
     * @apiGroup Credencial
     * @apiParam  {String} email Email do usuario
     * @apiParam  {String} password Senha do usuario
     * @apiParamExample  {json} Request-Example:
         {
             "email": "usuario@email.com",
             "password": "123456"
         }
        @apiSuccess (200) {String} token Token de usuario autenticado
        @apiSuccessExample {json} Success-Response:
            {
                "token": "abc.def.ghj.klm"
            }
        @apiErrorExample {json} Erro de autenticacao
            HTTP/1.1 401 Unauthorized
     */
    app.post('/token', (req, res) => {
        if (req.body.email && req.body.password) {
            const email = req.body.email;
            const senha = req.body.password;
            Users.findOne({ where: { email } })
                .then((user) => {
                    if (Users.isPassword(user.password, senha)) {
                        const payload = { id: user.id };
                        const token = jwt.encode(payload, config.jwtSecret);
                        res.json({ token });
                    } else {
                        res.sendStatus(401);
                    }
                })
                .catch((error) => res.sendStatus(401));
        } else {
            res.sendStatus(401);
        }
    });
}