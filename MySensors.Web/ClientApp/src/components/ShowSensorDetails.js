import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import AddSensor from "./AddSensor";
import {Add} from "@material-ui/icons";
import {NavMenu} from "./NavMenu";
import Grid from "@material-ui/core/Grid";
import {Link} from "react-router-dom";
import {FormControl, MenuItem, Paper, Select} from "@material-ui/core";
import TextField from "@material-ui/core/TextField";
import {ArgumentAxis, Chart, SplineSeries, BarSeries, ValueAxis} from "@devexpress/dx-react-chart-material-ui";
import {Animation, EventTracker, SelectionState} from "@devexpress/dx-react-chart";
import SensorsService from "../services/sensors.service";


export class ShowSensorDetails extends Component {
  static displayName = ShowSensorDetails.name;
  
  constructor(props) {
    super(props);
    this.DaysEnum = Object.freeze({"Series":1, "BarSeries":2})
    this.state = {
        chartType: this.DaysEnum.Series, 
        dataRange: 60,
        sensorParameterId: null,
        sensorParameters: [],
        values:[],
        selection: null
    };
    
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  async componentDidMount() {
     await this.loadParameters(this.props.match.params.id);
     await this.loadValues(this.state.sensorParameterId, this.state.dataRange);
  }
    

  async handleInputChange(event) {
      const target = event.target;
      const value = target.type === 'checkbox' ? target.checked : target.value;
      const name = target.name;
      
      this.setState({
          [name]: value
      }, () =>  {
          if(name === "dataRange" || name === "sensorParameterId")
              this.loadValues(this.state.sensorParameterId, this.state.dataRange);
      });

      
  }
  
  render () {
    return (
        <Grid maxWidth="xs" container spacing={2}>
            <Grid item md={2}>
                <Select name="sensorParameterId" onChange={this.handleInputChange} style={{minWidth: 120}} value={this.state.sensorParameterId}>
                    { this.state.sensorParameters.map((sensorParameter, index) =>
                        <MenuItem value={sensorParameter.id}>{sensorParameter.humanReadableName}</MenuItem>
                    )}
                </Select>
            </Grid>
            <Grid item md={2}>
                <Select name="dataRange" onChange={this.handleInputChange} style={{minWidth: 120}} value={this.state.dataRange}>
                    <MenuItem value="60">Hour</MenuItem>
                    <MenuItem value="1440">Day</MenuItem>
                    <MenuItem value="44640">Month</MenuItem>
                    <MenuItem value="16293600">Year</MenuItem>
                </Select>
            </Grid>
            <Grid item md={2}>
                <Select name="chartType" onChange={this.handleInputChange} style={{minWidth: 120}} value={this.state.chartType}>
                    <MenuItem value={this.DaysEnum.Series}>Series</MenuItem>
                    <MenuItem value={this.DaysEnum.BarSeries}>Histogram</MenuItem>
                </Select>
            </Grid>
            <Grid item xs={12}>
                <Paper>
                    {this.state.selection != null && <span>Selected value: {this.state.selection}</span>}
                    <Chart key={new Date().getTime()} data={this.state.values}>
                        <ArgumentAxis />
                        <ValueAxis />
                        {this.state.chartType === this.DaysEnum.Series && <SplineSeries name="spline" valueField="value" argumentField="updateDate" /> }
                        {this.state.chartType === this.DaysEnum.BarSeries && <BarSeries name="spline" valueField="value" argumentField="updateDate" /> }
                        <Animation />
                    </Chart>
                </Paper>
            </Grid>
        </Grid>
    );
  }

  async loadParameters(id) {
        try {
            const result = await SensorsService.getParametersBySensorId(id);
            if(result.status === 200)
            {
                await this.setState( {
                    sensorParameters: result.data,
                    sensorParameterId: result.data[0].id,
                    error: ""
                });
            }
        }
        catch
        {
            await this.setState({
                error: "Connection problems..."
            });
        }
  }

    async loadValues(id, periodInSeconds) {
        try {
            const result = await SensorsService.getValuesByParameterId(id, periodInSeconds);
            if(result.status === 200)
            {
                await this.setState( {
                    values: result.data,
                    error: ""
                });
            }
        }
        catch
        {
            await this.setState({
                error: "Connection problems..."
            });
        }
    }
}
