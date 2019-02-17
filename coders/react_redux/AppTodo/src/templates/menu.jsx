import React from 'react';

export default props => (
    <nav className="navbar navbar-inverse">
        <div className="container">
            <div className="navbar-header">
                <a className="navbar-brand" href="#">
                    <i className="fa fa-calendar-check-o"></i> TodoApp
                </a>
            </div>

            <div className="navbar-collapse collapse" id="navbar">
                <ul className="nav navbar-nav">
                    <li><a href="#/todos">Tarefas</a></li>
                    <li><a href="#/about">Sobre</a></li>
                </ul>
            </div>
        </div>
    </nav>
);
