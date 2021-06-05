import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import {Add} from "@material-ui/icons";
import {NavMenu} from "./NavMenu";
import NotFound from "./NotFound";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <NotFound />
    );
  }
}
