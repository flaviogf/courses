import React from 'react';

export default props => {
    let cols = '';
    let classeCss = '';

    if(props.cols) {
        cols = props.cols.split(' ');
        classeCss = '';

        if(cols[0]) {
            classeCss += `col-xs-${cols[0]}`;
        }

        if(cols[1]){
            classeCss += ` col-sm-${cols[1]}`;
        }

        if(cols[2]) {
            classeCss += ` col-md-${cols[2]}`;
        }

        if(cols[3]) {
            classeCss += ` col-lg-${cols[3]}`;
        }
    } else {
        classeCss = 'col-xs-12';
    }

    return(
        <div className={classeCss} >
            {props.children}
        </div>
    );
};
