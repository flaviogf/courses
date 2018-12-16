import React from 'react';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { markAsDone, markAsPending } from './todoActions';

import IconButton from '../templates/iconButton';

const TodoList = props => {

    const renderRows = () => {
        const list = props.list || [];
        return list.map(item => (
            <tr key={item._id}>
                <td className={ item.done ? 'markAsDone' : '' } >{item.description}</td>
                <td className="tableActions">
                    <IconButton btnType="success" icon="check" onClick={() => props.markAsDone(item)} hide={item.done}/>
                    <IconButton btnType="warning" icon="undo"  onClick={() => props.markAsPending(item)} hide={!item.done}/>
                    <IconButton btnType="danger" icon="trash-o" onClick={() => props.handleRemove(item)} hide={!item.done}/>
                </td>
            </tr>
        ));
    };

    return (
        <div>
            <table className="table">
                <thead>
                    <tr>
                        <th>
                            Descrição
                        </th>
                        <th>
                            Ações
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {renderRows()}
                </tbody>
            </table>
        </div>
    );
};

const mapStateToProps = state => ({list: state.todo.list});
const mapDispatchToProps = dispatch => bindActionCreators({ markAsDone, markAsPending }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(TodoList);
