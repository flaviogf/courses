import 'module/bootstrap/dist/css/bootstrap.min.css';
import 'module/font-awesome/css/font-awesome.min.css';
import '../templates/custom.css';

import React from 'react';
import Menu from '../templates/menu';
import Routes from './routes';

export default props => (
    <div className="container">
        <Menu />
        <Routes />
    </div>
);
