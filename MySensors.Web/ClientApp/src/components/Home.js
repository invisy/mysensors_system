import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import AddSensor from "./AddSensor";
import {Add} from "@material-ui/icons";
import {NavMenu} from "./NavMenu";
import {ShowSensorDetails} from "./ShowSensorDetails";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <ShowSensorDetails />
    );
  }
}
