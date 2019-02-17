import React, { Component } from 'react';
import axios from 'axios';

import PageHeader from '../templates/pageHeader';
import TodoForm from './todoForm';
import TodoList from './todoList';

const url = 'http://localhost:3003/api/todos';

export default class Todo extends Component {
    constructor(props) {
        super(props);
        this.state = { description: '', list: [] };

        this.handleChange = this.handleChange.bind(this);
        this.handleAdd = this.handleAdd.bind(this);
        this.handleRemove = this.handleRemove.bind(this);
        this.handleMarkAsDone = this.handleMarkAsDone.bind(this);
        this.handleMarkAsUnfinished = this.handleMarkAsUnfinished.bind(this);
        this.handleSearch = this.handleSearch.bind(this);
        this.handleClear = this.handleClear.bind(this);
        this.refresh = this.refresh.bind(this);

        this.refresh();
    }

    refresh(description = '') {
        const filtro = description ? `&description__regex=/${description}/` : '';
        axios.get(`${url}/?sort=-createdAt${filtro}`).then(resultado => {
            this.setState({ ...this.state, description, list: resultado.data });
        });
    }

    handleChange(e) {
        this.setState({...this.state, description: e.target.value});
    }

    handleAdd() {
        const description = this.state.description;
        axios.post(url, { description }).then(() => this.refresh());
    }

    handleRemove(item) {
        axios.delete(`${url}/${item._id}`).then(() => this.refresh(this.state.description));
    }

    handleSearch() {
        this.refresh(this.state.description);
    }

    handleClear() {
        this.refresh();
    }

    handleMarkAsDone(item) {
        axios.put(`${url}/${item._id}`, { ...item, done: true }).then(() => this.refresh(this.state.description));
    }

    handleMarkAsUnfinished(item) {
        axios.put(`${url}/${item._id}`, { ...item, done: false }).then(() => this.refresh(this.state.description));
    }

    render() {
        return (
            <div>
                <PageHeader name="Tarefas" small="Cadastro" />
                <TodoForm 
                    handleChange={this.handleChange}
                    handleAdd={this.handleAdd}
                    handleSearch={this.handleSearch}
                    handleClear={this.handleClear}
                    value={this.state.description}
                />
                <TodoList
                    handleMarkAsDone={this.handleMarkAsDone}
                    handleMarkAsUnfinished={this.handleMarkAsUnfinished}
                    list={this.state.list} handleRemove={this.handleRemove}/>
            </div>
        );
    }
}
