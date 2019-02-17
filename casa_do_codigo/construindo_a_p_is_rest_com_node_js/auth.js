import passport from 'passport';
import { ExtractJwt, Strategy } from 'passport-jwt';

module.exports = (app) => {
    const Users = app.db.models.Users;
    const config = app.libs.config;
    const strategy = new Strategy({ secretOrKey: config.jwtSecret, jwtFromRequest: ExtractJwt.fromAuthHeaderWithScheme('jwt') }, (payload, done) => {
        Users.findOne({ where: payload.id })
            .then((user) => {
                if (user) {
                    return done(null, {
                        id: user.id,
                        email: user.email
                    });
                }
                return done(null, false);
            })
            .catch((error) => done(error, false));
    });
    passport.use(strategy);
    return {
        initialize: () => {
            return passport.initialize();
        },
        authenticate: () => {
            return passport.authenticate('jwt', config.jwtSession)
        }
    }
}