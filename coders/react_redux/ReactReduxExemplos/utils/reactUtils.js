import React from 'react';

function filhosComPropriedades (children, props) {
    return React.Children.map(children, child => React.cloneElement(child, props));
}

export { filhosComPropriedades };