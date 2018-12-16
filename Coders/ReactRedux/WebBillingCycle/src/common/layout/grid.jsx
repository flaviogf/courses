import React, { Component } from 'react';

class Grid extends Component {
  toClasseCss() {
    const numeros = this.props.cols ? this.props.cols : '12';
    let arrayNumeros = numeros ? numeros.split(' ') : [];
    let classe = 'col ';
    if (arrayNumeros[0]) {
      classe += `s${arrayNumeros[0]} `;
    }
    if (arrayNumeros[1]) {
      classe += `m${arrayNumeros[1]} `;
    }
    if (arrayNumeros[2]) {
      classe += `l${arrayNumeros[2]} `;
    }
    return classe;
  }

  render() {
    const classeCss = this.toClasseCss();
    return <div className={classeCss}>{this.props.children}</div>;
  }
}

export default Grid;
