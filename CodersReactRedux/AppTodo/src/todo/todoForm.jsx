import React from 'react';

import Grid from '../templates/grid';
import IconButton from '../templates/iconButton';

export default props => {
    const keyUp = (e) => {
        if(e.keyCode == 13){
            e.shiftKey ? props.handleSearch() : props.handleAdd();
        }

        if(e.keyCode == 27) {
            props.handleClear();
        }
    }

    return (
        <div role="form" className="todoForm">
            <Grid cols="12 9 10">
                <input className="form-control" id="description"
                type="text" placeholder="Adicione uma tarefa"
                value={props.value}
                onKeyUp={keyUp}
                onChange={props.handleChange}
                />            
            </Grid>

            <Grid cols="12 3 2" >
                <IconButton btnType="primary" icon="plus" onClick={() => props.handleAdd()} />
                <IconButton btnType="info" icon="search" onClick={() => props.handleSearch()} />
                <IconButton btnType="default" icon="close" onClick={() => props.handleClear()} />
            </Grid>
        </div>
    );
};
