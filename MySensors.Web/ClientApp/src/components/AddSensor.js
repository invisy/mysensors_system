import React, {Component} from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import RemoveCircleOutlineRoundedIcon from '@material-ui/icons/RemoveCircleOutlineRounded';
import {green, red} from "@material-ui/core/colors";
import SensorsService from '../services/sensors.service'

const useStyles = theme => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  }
});

class AddSensor extends Component {
  static displayName = AddSensor.name;
  
  constructor(props) {
    super(props);
    this.state = { 
      sensorInfo: { 
          sensorName: "", 
          sensorParameters: [{
            humanReadableName: "",
            requestName: ""
        }] 
      }
    };
    this.changeName = this.changeName.bind(this);
    this.changeParameterHumanName = this.changeParameterHumanName.bind(this);
    this.changeParameterRequestName = this.changeParameterRequestName.bind(this);
    this.addItem = this.addItem.bind(this);
    this.removeItem = this.removeItem.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  changeName(event) {
    const target = event.target;
    this.state.sensorInfo.sensorName = target.value;
    this.forceUpdate();
  }

  changeParameterHumanName(event, id) {
    const target = event.target;
    this.state.sensorInfo.sensorParameters[id].humanReadableName = target.value;
    this.forceUpdate();
  }

  changeParameterRequestName(event, id) {
    const target = event.target;
    this.state.sensorInfo.sensorParameters[id].requestName = target.value;
    this.forceUpdate();
  }

  addItem()
  {
    this.state.sensorInfo.sensorParameters.push({humanReadableName: "", requestName: ""});

    this.forceUpdate();
  }
  
  removeItem(event, id)
  {
    if(this.state.sensorInfo.sensorParameters.length > 1)
      this.state.sensorInfo.sensorParameters.splice(id, 1);

    this.forceUpdate();
  }
  
  async handleSubmit(event)
  {
    event.preventDefault();
    await this.addSensor(this.state.sensorInfo)
  }
  
  render () {
    const { classes } = this.props;

    return (
        <Container component="main" maxWidth="md">
          <CssBaseline/>
          <div className={classes.paper}>
            <Avatar className={classes.avatar}>
              <AddCircleIcon/>
            </Avatar>
            <Typography component="h1" variant="h5">
              Add Sensor
            </Typography>
            {this.state.error && <Alert xs variant="outlined" severity="error">{this.state.error}</Alert>}
            <form className={classes.form} noValidate onSubmit={this.handleSubmit}>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <TextField
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      id="name"
                      label="Sensor name"
                      name="sensorName"
                      autoComplete="name"
                      autoFocus
                      value={this.state.sensorInfo.sensorName}
                      onChange={this.changeName}
                  />
                </Grid>
                {this.state.sensorInfo.sensorParameters.map((parameter, index) =>
                    <Grid alignItems="stretch" key={index} container spacing={2} item>
                      <Grid item xs={10} sm={5}>
                        <TextField
                            name="humanReadableName"
                            variant="outlined"
                            required
                            fullWidth
                            id="humanReadableName"
                            label={"Readable parameter " + (index+1) + " name"}
                            value={parameter.humanReadableName}
                            onChange={e => this.changeParameterHumanName(e, index)}
                        />
                      </Grid>
                      <Grid item xs={10} sm={5}>
                        <TextField
                            variant="outlined"
                            required
                            fullWidth
                            id="requestName"
                            label={"Parameter " + (index+1) + "  name for request"}
                            name="requestName"
                            value={parameter.requestName}
                            onChange={e => this.changeParameterRequestName(e, index)}
                        />
                      </Grid>
                      {index > 0 && <Grid style={{display: "flex", flexDirection: "column"}} item xs={1} sm={2}>
                        <Button onClick={e => this.removeItem(e, index)}
                            style={{height: "100%"}}
                            startIcon={<RemoveCircleOutlineRoundedIcon style={{fontSize: 30, color: red[500]}}/>}
                        />
                      </Grid>}
                    </Grid>
                )}
                <Grid style={{display: "flex", flexDirection: "column"}} item xs={1} sm={2}>
                  <Button onClick={this.addItem}
                       startIcon={<AddCircleOutlineIcon style={{fontSize: 30, color: green[500]}}/>} 
                  />
                </Grid>
              </Grid>
              <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  className={classes.submit}
              >
                Add
              </Button>
            </form>
          </div>
        </Container>
    );
  }

  async addSensor(sensor) {
    try {
      await SensorsService.addSensor(sensor);
      window.location.href = "/sensors";
    }
    catch(e)
    {
      /*this.setState({
        error: e
      });*/
    }
    
  }
}

AddSensor.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(useStyles)(AddSensor);