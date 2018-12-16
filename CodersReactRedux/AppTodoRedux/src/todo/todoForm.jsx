import React, { Component } from 'react';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import Grid from '../templates/grid';
import IconButton from '../templates/iconButton';

import { add, changedDescription, search } from './todoActions';

class TodoForm extends Component {
    constructor(props) {
        super(props);

        this.keyUp = this.keyUp.bind(this);
    }

    componentWillMount() {
        this.props.search();
    }

    keyUp(e) {
        const { add, search, description } = this.props;
        if(e.keyCode == 13){
            e.shiftKey ? search() : add(description);
        }

        if(e.keyCode == 27) {
            this.props.handleClear();
        }
    }

    render() {
        const { add, changedDescription, search, description } = this.props;
        return (
            <div role="form" className="todoForm">
                <Grid cols="12 9 10">
                    <input className="form-control" id="description"
                    type="text" placeholder="Adicione uma tarefa"
                    value={description}
                    onKeyUp={this.keyUp}
                    onChange={changedDescription}
                    />            
                </Grid>

                <Grid cols="12 3 2" >
                    <IconButton btnType="primary" icon="plus" onClick={() => add(description)} />
                    <IconButton btnType="info" icon="search" onClick={() => search()} />
                    <IconButton btnType="default" icon="close" onClick={() => this.props.handleClear()} />
                </Grid>
            </div>
        ); 
    }
}

const mapStateToProps = state => ({description: state.todo.description});

const mapDispatchToProps = dispatch => bindActionCreators({
    add,
    changedDescription,
    search
}, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(TodoForm);
