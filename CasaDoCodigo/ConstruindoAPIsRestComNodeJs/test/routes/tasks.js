import jwt from 'jwt-simple';
describe('Routes: Tasks', () => {
    const Users = app.db.models.Users;
    const Tasks = app.db.models.Tasks;
    const jwtSecret = app.libs.config.jwtSecret;
    let token;
    let fakeTask;
    beforeEach((done) => {
        Users.destroy({ where: {} })
            .then(() => Users.create({
                name: 'flavio',
                email: 'flavio@email.com',
                password: '123456'
            }))
            .then(user => {
                Tasks.destroy({ where: {} })
                    .then(() => Tasks.bulkCreate([
                        {
                            id: 1,
                            title: 'Estudar',
                            user_id: user.id
                        },
                        {
                            id: 2,
                            title: 'Trabalhar',
                            user_id: user.id
                        }
                    ]))
                    .then(tasks => {
                        fakeTask = tasks[0];
                        token = jwt.encode({ id: user.id }, jwtSecret);
                        done();
                    })
            });
    });
    describe('Get /tasks', () => {
        it('lista de tarefas', (done) => {
            request.get('/tasks')
                .set('Authorization', `JWT ${token}`)
                .expect(200)
                .end((err, res) => {
                    expect(res.body.tasks).to.have.length(2);
                    done(err);
                });
        });
    });
    describe('Post /taks', () => {
        it('criar tarefa', (done) => {
            request.post('/taks')
                .set('Authorization', `JWT ${token}`)
                .send({ title: 'Run' })
                .expect(201)
                .end((err, res) => {
                    expect(res.body.title).to.eql('Run');
                    done(err);
                });
            done();
        });
    });
    describe('Get tasks/:id', () => {
        describe('status 200', () => {
            it('retorna uma tarefa', (done) => {
                request.get(`/tasks/${fakeTask.id}`)
                    .set('Authorization', `JWT ${token}`)
                    .expect(200)
                    .end((err, res) => {
                        expect(res.body.title).to.eql('Estudar');
                        done(err);
                    });
            });
        });
        describe('status 404', () => {
            it('erro 404', (done) => {
                request.get('/tasks/0')
                    .set('Authorization', `JWT ${token}`)
                    .expect(404)
                    .end((err, res) => {
                        done(err);
                    });
            });
        });
    });
    describe('Put tasks/:id', () => {
        describe('status 204', () => {
            it('atualizar tarefa', (done) => {
                request.put(`/tasks/${fakeTask.id}`)
                    .set('Authorization', `JWT ${token}`)
                    .send({
                        title: 'Test',
                        done: true
                    })
                    .expect(204)
                    .end((err, res) => {
                        done(err);
                    });
            });
        });
    });
    describe('Delete tasks/:id', () => {
        describe('status 204', () => {
            it('remover tarefa', (done) => {
                request.delete(`/tasks/${fakeTask.id}`)
                    .set('Authorization', `JWT ${token}`)
                    .expect(204)
                    .end((err, res) => {
                        done(err);
                    });
            });
        });
    });
});