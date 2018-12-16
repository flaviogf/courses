import React from 'react';
import { filhosComPropriedades } from '../utils/reactUtils';
export default props => (
    <div>
        <h1>Família</h1>
        { filhosComPropriedades(props.children, {...props}) }
    </div>
);
