import React from 'react';

export default props => {
    const btnType = `btn btn-${props.btnType}`;
    const icon = `fa fa-${props.icon}`;
    const hide = props.hide ? 'hidden' : '';

    return (
        <button className={`${btnType} ${hide}`} onClick={props.onClick}>
            <i className={icon}></i>
        </button>
    );
};
