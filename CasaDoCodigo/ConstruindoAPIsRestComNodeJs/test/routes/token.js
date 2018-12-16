describe('Routes: Token', () => {
    const Users = app.db.models.Users;
    describe('Post /token', () => {
        beforeEach((done) => {
            Users.destroy({ where: {} })
                .then(() => Users.create({
                    name: 'flavio',
                    email: 'flavio@email.com',
                    password: '123456'
                }).then(() => done()));
        });
        describe('status 200', () => {
            it('usuario autenticado', (done) => {
                request.post('/token')
                    .send({
                        email: 'flavio@email.com',
                        password: '123456'
                    })
                    .expect(200)
                    .end((err, res) => {
                        expect(res.body).to.have.all.keys('token');
                        done(err);
                    });
            });
        });
        describe('status 401', () => {
            it('senha incorreta', (done) => {
                request.post('/token')
                    .send({
                        email: 'flavio@email.com',
                        password: '1234567'
                    })
                    .expect(401)
                    .end((err, res) => {
                        done(err);
                    });
            });
            it('email nao existe', (done) => {
                request.post('/token')
                    .send({
                        email: 'teste',
                        password: 'teste'
                    })
                    .expect(401)
                    .end((err, res) => {
                        done(err);
                    })
            });
            it('sem email e senha', (done) => {
                request.post('/token')
                    .expect(401)
                    .end((err, res) => {
                        done(err);
                    });
            });
        });
    });
});