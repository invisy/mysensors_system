import React, { Component } from 'react';
import Button from '@material-ui/core/Button';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <Button variant="contained" color="primary"> Hello World </Button>
    );
  }
}
