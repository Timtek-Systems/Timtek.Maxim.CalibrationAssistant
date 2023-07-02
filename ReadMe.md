# ACP Scheduler Auto-Calibration Assistant

A command-line utility that will update MaxIm DL's calibration wizard
so that it always has calibration groups populated with relevant, recent frames.
This allows ACP's "Auto-calibrate final images" option to be usable and useful.

## User Story

As an observer, I want every image frame to be automatically calibrated using recent appropriate calibration frames,
so that I don't need to perform that step manually.

The aim of the utility is to populate MaxIm DL's Calibration Wizard with recent calibration frames, so that
Auto-Calibration is usable and useful.

The utility can be run at the start of an imaging session, at the end of the scheduler CalFrame acquisition,
or perhaps even before every observing plan as part of the image acquisition cycle.

ACP's `Auto-Calibrate Final Images` option can then be enabled,
in the knowledge that there will always be a supply of appropriate and recent calibration frames.

## Theory of Operation

Given a "target specification" with the desired set of calibration frames,
the utility will scan a folder hierarchy in reverse-chronological order looking for FITS frames
that match the specification.

The specification will consist of one or more `Channels`.

Each `Channel` will be constrained by:

- Frame type (Dark, Bias, Flat)
- Exposure duration in seconds
- Sensor temperature in °C at the time of the exposure
- Binning
- Maximum age (elapsed time since exposure) of the frames, in days
- The desired number of frames
- The minimum number of frames that must be present for the channel to be useful.

An example channel specification would be:
> Dark frames exposed for 300 seconds at -30°C, unbinned, and no older than 90 days; A minimum of 20 frames and ideally 40 or more.

The utility will scan calibration frames on disk and attempt to discover a list of frames that satisfies the channel specifications.
It will then pass these frames to MaxIm DL to be built into calibration groups within the Calibration Wizard.

The utility can be run daily before imaging commences, or after calibration frame acquisition, to keep MaxIm always up to date.
ACP 'auto calibration' can then be turned on and will be useful as it will be based on up-to-date calibration data.

## Flat Field Frames

It is not proposed to support flat field frames in the initial release.
MaxIm is deficient in its handling of flat fields where a rotator is used, which hampers automation.
This is an area for possible improvement in subsequent versions.

## Issues Anticipated

MaxIm DL's scripting engine only allows frames to be passed in in entire folders.
It will accept multiple folders, but will incorporate all frames in the folder.
Calibration frames on disk may not be so organized so a solution must be found for this.

One approach is to create a temporary location and populate it with "soft links" to the source files.
It is expected that we will create a folder for each run, named for the date and time of the run, in a designated location.
Beneath that folder we will create a folder for each valid "channel".
The channel folders will be populated with soft-links to the discovered source files.
The channel folders will then all be passed to MaxIm DL to be used for creating calibration groups.

## Channel Specifications

The channel specifications will be contained in a JSON document containing an array of channel objects.
This is the approximate format:

```json
[
    {
        "name" : "channel name",    // Human readable, for use in logs and GUI
        "frameType" : "Dark"        // Dark or Bias
        "Exposure" : 300,           // Required exposure time in seconds
        "Temperature": -30,         // Required sensor temperature in °C
        "Binning" : 1,              // Binning, 1..4, assumed square.
        "maxAge" : 90,              // Maximum frame age in days
        "minFrames" : 20,           // The minimum number of useful frames below which the channel will not be used.
        "desiredFrames" : 40        // The target number of frames for the channel
    },
]
```
