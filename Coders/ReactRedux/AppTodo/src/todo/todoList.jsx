import React from 'react';
import IconButton from '../templates/iconButton';

export default props => {

    const renderRows = () => {
        const list = props.list || [];
        return list.map(item => (
            <tr key={item._id}>
                <td className={ item.done ? 'markAsDone' : '' } >{item.description}</td>
                <td className="tableActions">
                    <IconButton btnType="success" icon="check" onClick={() => props.handleMarkAsDone(item)} hide={item.done}/>
                    <IconButton btnType="warning" icon="undo"  onClick={() => props.handleMarkAsUnfinished(item)} hide={!item.done}/>
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
