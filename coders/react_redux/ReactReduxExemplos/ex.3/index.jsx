import React from 'react';
import ReactDOM from 'react-dom';
import Family from './family';
import Member from './member';

ReactDOM.render(
    <Family lastName="Fernandes">
        <Member name="Flavio" />
        <Member name="Fernando" />
    </Family>
, document.getElementById('app'));
