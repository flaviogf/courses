import React from 'react';
import { Router, Route, Redirect, hashHistory } from 'react-router';

import Todo from '../todo/todo';
import Sobre from '../about/about';

export default props => (
    <Router history={hashHistory}>
        <Route path="/todos" component={Todo}/>
        <Route path="/about" component={Sobre}/>
        <Redirect from="*" to="/todos"/>
    </Router>
);
