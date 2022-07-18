// Copyright 2022 Ben Voß
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files
// (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace ImpulseRocketry.GCode;

public sealed class GCodeWriter {
    private bool _startOfLine = true;
    private readonly TextWriter _writer;

    public GCodeWriter (TextWriter writer) {
        _writer = writer;
    }

    public GCodeWriter LinearMove(double? f = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(0).Param("F", f).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter LinearMoveAndExtrude(double? e = null, double? f = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(1).Param("E", e).Param("F", f).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }
    
    public GCodeWriter ArcMoveClockwise(double? e = null, double? f = null, double? i = null, double? j = null, double? p = null, double? r = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(2).Param("E", e).Param("F", f).Param("I", i).Param("J", j).Param("P", p).Param("R", r).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter ArcMoveCounterClockwise(double? e = null, double? f = null, double? i = null, double? j = null, double? p = null, double? r = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(3).Param("E", e).Param("F", f).Param("I", i).Param("J", j).Param("P", p).Param("R", r).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter Dwell(double? p = null, double? s = null, string? comment = null) {
        return GCommand(4).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter BezierCubicSpline(double? e = null, double? f = null, double? i = null, double? j = null, double? p = null, double? q = null, double? s = null, double? x = null, double? y = null, string? comment = null) {
        return GCommand(5).Param("E", e).Param("F", f).Param("I", i).Param("J", j).Param("P", p).Param("Q", q).Param("S", s).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter DirectStepperMove(double? e = null, double? i = null, double? r = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(6).Param("E", e).Param("I", i).Param("R", r).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }
    
    public GCodeWriter Retract(double? s = null, string? comment = null) {
        return GCommand(10).Param("S", s).Comment(comment);
    }

    public GCodeWriter Recover(string? comment = null) {
        return GCommand(11).Comment(comment);
    }

    public GCodeWriter CleanTheNozzle(int? p = null, double? r = null, int? s = null, int? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(12).Param("P", p).Param("R", r).Param("S", s).Param("S", s).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter CncWorkspacePlaneXY(string? comment = null) {
        return GCommand(17).Comment(comment);
    }

    public GCodeWriter CncWorkspacePlaneZX(string? comment = null) {
        return GCommand(18).Comment(comment);
    }

    public GCodeWriter CncWorkspacePlaneYZ(string? comment = null) {
        return GCommand(19).Comment(comment);
    }

    public GCodeWriter InchUnits(string? comment = null) {
        return GCommand(20).Comment(comment);
    }

    public GCodeWriter MillimeterUnits(string? comment = null) {
        return GCommand(21).Comment(comment);
    }

    public GCodeWriter MeshValidationPattern(double? b = null, bool? c = null, bool? d = null, double? f = null, double? h = null, int? i = null, double? k = null, double? l = null, double? o = null, double? p = null, double? q = null, int? r = null, double? s = null, double? u = null, double? x = null, double? y = null, string? comment = null) {
        return GCommand(26).Param("B", b).Param("C", c).Flag("D", d).Param("F", f).Param("H", h).Param("I", i).Param("K", k).Param("L", l).Param("O", o).Param("P", p).Param("Q", q).Param("R", r).Param("S", s).Param("U", u).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter ParkToolhead(int? p = null, string? comment = null) {
        return GCommand(27).Param("P", p).Comment(comment);
    }

    public GCodeWriter AutoHome(bool? l = null, bool? o = null, bool? r = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return GCommand(28).Flag("L", l).Flag("O", o).Flag("R", r).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter BedLeveling(string? comment = null) {
        return GCommand(29).Comment(comment);
    }

    public GCodeWriter BedLeveling3Point(bool? a = null, bool? c = null, bool? d = null, bool? e = null, bool? j = null, bool? o = null, bool? q = null, int? v = null, string? comment = null) {
        return GCommand(29).Param("A", a).Param("C", c).Param("D", d).Param("E", e).Param("J", j).Flag("O", o).Param("Q", q).Param("V", v).Comment(comment);
    }

    public GCodeWriter BedLevelingLinear(bool? a = null, double? b = null, bool? c = null, bool? d = null, double? f = null, double? h = null, bool? j = null, double? l = null, bool? o = null, int? p = null, bool? q = null, double? r = null, double? s = null, bool? t = null, int? v = null, int? x = null, int? y = null, string? comment = null) {
        return GCommand(29).Param("A", a).Param("B", b).Param("C", c).Param("D", d).Param("F", f).Param("H", h).Param("J", j).Param("L", l).Flag("O", o).Param("P", p).Param("Q", q).Param("R", r).Param("S", s).Param("T", t).Param("V", v).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter BedLevelingManual(bool? i = null, bool? j = null, int? s = null, int? x = null, int? y = null, double? z = null, string? comment = null) {
        return GCommand(29).Param("I", i).Param("J", j).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    } 
    
    public GCodeWriter BedLevelingBilinear(bool? a = null, double? b = null, bool? c = null, bool? d = null, bool? e = null, double? f = null, double? h = null, bool? j = null, double? l = null, bool? o = null, bool? q = null, double? r = null, double? s = null, int? v = null, bool? w = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(29).Param("A", a).Param("B", b).Param("C", c).Param("D", d).Param("E", e).Param("F", f).Param("H", h).Param("J", j).Param("L", l).Flag("O", o).Param("Q", q).Param("R", r).Param("S", s).Param("V", v).Param("W", w).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter BedLevelingUnified() {
        throw new NotImplementedException();
    }

    public GCodeWriter SingleZProbe(bool? c = null, bool? e = null, double? x = null, double? y = null, string? comment = null) {
        return GCommand(30).Flag("C", c).Flag("E", e).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter DockSled(string? comment = null) {
        return GCommand(31).Comment(comment);
    }

    public GCodeWriter UndockSled(string? comment = null) {
        return GCommand(32).Comment(comment);
    }

    public GCodeWriter DeltaAutoCalibration(double? c = null, bool? e = null, int? f = null, bool? o = null, int? p = null, double? r = null, bool? t = null, int? v = null, string? comment = null) {
        return GCommand(33).Param("C", c).Param("E", e).Param("F", f).Param("O", o).Param("P", p).Param("R", r).Param("T", t).Param("V", v).Comment(comment);
    }

    public GCodeWriter ZSteppersAutoAlignment(bool? a = null, bool? e = null, bool? i = null, bool? t = null, string? comment = null) {
        return GCommand(34).Flag("A", a).Flag("E", e).Flag("I", i).Flag("T", t).Comment(comment);
    }

    public GCodeWriter MechanicalGantryCalibration(double? s = null, double? z = null, string? comment = null) {
        return GCommand(34).Param("S", s).Param("Z", z).Comment(comment);
    }

    public GCodeWriter TrammingAssistant(int? s = null, string? comment = null) {
        return GCommand(35).Param("S", s).Comment(comment);
    }

    public GCodeWriter ProbeTarget(int subCommand, double? f = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(38).SubCommand(subCommand).Param("F", f).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter MoveToMeshCoordinate(double? f = null, int? i = null, int? j = null, string? comment = null) {
        return GCommand(42).Param("F", f).Param("I", i).Param("J", j).Comment(comment);
    }

    public GCodeWriter WithMoveInMachineCoordinates() {
        return GCommand(53).Write(" ");
    }

    public GCodeWriter MoveInMachineCoordinates(string? comment = null) {
        return GCommand(53).Comment(comment);
    }

    public GCodeWriter WorkspaceCoordinateSystem(int coordinteSystem, string? comment = null) {
        if (coordinteSystem >= 1 && coordinteSystem <= 6) {
            return GCommand(53 + coordinteSystem).Comment(comment);
        }

        return GCommand(59).SubCommand(coordinteSystem - 6).Comment(comment);
    }

    public GCodeWriter SaveCurrentPosition(string? comment = null) {
        return GCommand(60).Comment(comment);
    }

    public GCodeWriter ReturnToSavedPosition(bool? e = null, double? f = null, int? s = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return GCommand(61).Flag("E", e).Param("F", f).Param("S", s).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter ProbeTemperatureCalibration(bool? b = null, bool? p = null, string? comment = null) {
        return GCommand(76).Flag("B", b).Param("P", p).Comment(comment);
    }

    public GCodeWriter CancelCurrentMotionMode(string? comment = null) {
        return GCommand(80).Comment(comment);
    }

    public GCodeWriter AbsolutePositioning(string? comment = null) {
        return GCommand(90).Comment(comment);
    }

    public GCodeWriter RelativePositioning(string? comment = null) {
        return GCommand(91).Comment(comment);
    }

    public GCodeWriter SetPosition(double? e = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return GCommand(92).Param("E", e).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter BacklashCalibration(bool? b = null, double? t = null, double? u = null, bool? v = null, string? comment = null) {
        return GCommand(92).Flag("B", b).Param("T", t).Param("U", u).Flag("V", v).Comment(comment);
    }


    public GCodeWriter UnconditionalStop(double? p = null, double? s = null, string? message = null, string? comment = null) {
        return MCommand(0).Param("P", p).Param("S", s).Param(message).Comment(comment);
    }

    public GCodeWriter SpindleCwOrLaserOn(int? i = null, double? o = null, double? s = null, string? comment = null) {
        return MCommand(3).Param("I", i).Param("O", o).Param("S", s).Comment(comment);
    }

    public GCodeWriter SpindleCcwOrLaserOn(int? i = null, double? o = null, double? s = null, string? comment = null) {
        return MCommand(4).Param("I", i).Param("O", o).Param("S", s).Comment(comment);
    }

    public GCodeWriter SpindleOrLaserOff(string? comment = null) {
        return MCommand(5).Comment(comment);
    }

    public GCodeWriter CoolantMistOn(string? comment = null) {
        return MCommand(7).Comment(comment);
    }

    public GCodeWriter CoolantSpindleFloodOrLaserAirOn(string? comment = null) {
        return MCommand(8).Comment(comment);
    }

    public GCodeWriter CoolantOff(string? comment = null) {
        return MCommand(9).Comment(comment);
    }

    public GCodeWriter VacuumBlowerOn(string? comment = null) {
        return MCommand(10).Comment(comment);
    }

    public GCodeWriter VacuumBlowerOff(string? comment = null) {
        return MCommand(11).Comment(comment);
    }

    public GCodeWriter ExpectedPrinterCheck(string machineName, string? comment = null) {
        return MCommand(16).Param(machineName).Comment(comment);
    }

    public GCodeWriter EnableSteppers(bool? e = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(17).Flag("E", e).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter DisableSteppers(bool? e = null, double? s = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(18).Flag("E", e).Param("S", s).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter ListSdCard(bool? l = null, string? comment = null) {
        return MCommand(20).Flag("L", l).Comment(comment);
    }

    public GCodeWriter InitSdCard(string? comment = null) {
        return MCommand(21).Comment(comment);
    }

    public GCodeWriter ReleaseSdCard(string? comment = null) {
        return MCommand(22).Comment(comment);
    }

    public GCodeWriter SelectSdCard(string filename, string? comment = null) {
        return MCommand(23).Param(filename).Comment(comment);
    }

    public GCodeWriter StartOrResumeSdPrint(double? s = null, double? t = null, string? comment = null) {
        return MCommand(24).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter PauseSdPrint(string? comment = null) {
        return MCommand(25).Comment(comment);
    }

    public GCodeWriter SetSdPositionPrint(double? s = null, string? comment = null) {
        return MCommand(26).Param("S", s).Comment(comment);
    }

    public GCodeWriter ReportSdPrintStatus(bool? c = null, double? s = null, string? comment = null) {
        return MCommand(27).Flag("C", c).Param("S", s).Comment(comment);
    }

    public GCodeWriter StartSdWrite(string filename, bool? b1 = null, string? comment = null) {
        return MCommand(28).Flag("B1", b1).Param(filename).Comment(comment);
    }

    public GCodeWriter StopSdWrite(string? comment = null) {
        return MCommand(29).Comment(comment);
    }

    public GCodeWriter DeleteSdFile(string filename, string? comment = null) {
        return MCommand(30).Param(filename).Comment(comment);
    }
    
    public GCodeWriter PrintTime(string? comment = null) {
        return MCommand(31).Comment(comment);
    }

    public GCodeWriter SelectAndStart(string filename, bool? p = null, int? s = null, string? comment = null) {
        return MCommand(32).Param("P", p).Param("S", s).Param(filename).Comment(comment);
    }

    public GCodeWriter GetLondPath(string filename, string? comment = null) {
        return MCommand(33).Param(filename).Comment(comment);
    }

    public GCodeWriter SdCardSorting(int? f = null, bool? s = null, string? comment = null) {
        return MCommand(34).Param("F", f).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetPinState(bool? i = null, int? p = null, int? s = null, int? t = null, string? comment = null) {
        return MCommand(42).Param("I", i).Param("P", p).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter DebugPins(bool? e = null, bool? i = null, int? p = null, bool? s = null, bool? t = null, bool? w = null, string? comment = null) {
        return MCommand(42).Param("E", e).Flag("I", i).Param("P", p).Flag("S", s).Flag("T", t).Flag("W", w).Comment(comment);
    }

    public GCodeWriter TogglePins(bool? i = null, int? l = null, int? r = null, bool? s = null, int? w = null, string? comment = null) {
        return MCommand(43).Param("I", i).Param("L", l).Param("R", r).Param("S", s).Param("W", w).Comment(comment);
    }

    public GCodeWriter ProbeRepeatabilityTest(bool? c = null, int? e = null, int? l = null, int? p = null, int? s = null, int? v = null, double? x = null, double? y = null, string? comment = null) {
        return MCommand(48).Param("C", c).Param("E", e).Param("L", l).Param("P", p).Param("S", s).Param("V", v).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter SetPrintProgress(double? p = null, double? r = null, string? comment = null) {
        return MCommand(73).Param("P", p).Param("R", r).Comment(comment);
    }

    public GCodeWriter StartPrintJobTimer(string? message = null, string? comment = null) {
        return MCommand(75).Param(message).Comment(comment);
    }

    public GCodeWriter PausePrintJob(string? comment = null) {
        return MCommand(76).Comment(comment);
    }

    public GCodeWriter StopPrintJobTimer(string? comment = null) {
        return MCommand(77).Comment(comment);
    }

    public GCodeWriter PrintJobStats(string? comment = null) {
        return MCommand(78).Comment(comment);
    }

    public GCodeWriter PowerOn(bool? s = null, string? comment = null) {
        return MCommand(80).Flag("S", s).Comment(comment);
    }

    public GCodeWriter PowerOff(string? comment = null) {
        return MCommand(81).Comment(comment);
    }

    public GCodeWriter AbsoluteExtrusionMode(string? comment = null) {
        return MCommand(82).Comment(comment);
    }

    public GCodeWriter RelativeExtrusionMode(string? comment = null) {
        return MCommand(83).Comment(comment);
    }

    public GCodeWriter InactivityShutdown(int? s = null, string? comment = null) {
        return MCommand(85).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetAxisStepsPerUnit(int? e = null, int? t = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(85).Param("E", e).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter FreeMemory(int? c = null, bool? d = null, bool? f = null, bool? i = null, string? comment = null) {
        return MCommand(85).Param("C", c).Flag("D", d).Flag("F", f).Flag("I", i).Comment(comment);
    }

    public GCodeWriter SetHotendTemperature(double? b = null, bool? f = null, int? i = null, double? s = null, int? t = null, string? comment = null) {
        return MCommand(104).Param("B", b).Flag("F", f).Param("I", i).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter ReportTemperatures(bool? r = null, int? i = null, string? comment = null) {
        return MCommand(105).Flag("R", r).Param("I", i).Comment(comment);
    }

    public GCodeWriter SetFanSpeed(int? i = null, int? p = null, int? s = null, int? t = null, string? comment = null) {
        return MCommand(106).Param("I", i).Param("P", p).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter FanOff(string? comment = null) {
        return MCommand(107).Comment(comment);
    }

    public GCodeWriter BreakAndContinue(string? comment = null) {
        return MCommand(108).Comment(comment);
    }

    public GCodeWriter WaitForHotendTemperature(int? b = null, bool? f = null, int? i = null, int? r = null, double? s = null, int? t = null, string? comment = null) {
        return MCommand(109).Param("B", b).Param("F", f).Param("I", i).Param("R", r).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter SetLineNumber(int n, string? comment = null) {
        return MCommand(110).Param("N", n).Comment(comment);
    }

    public GCodeWriter DebugLevel(int? s = null, string? comment = null) {
        return MCommand(111).Param("S", s).Comment(comment);
    }

    public GCodeWriter EmergencyStop(string? comment = null) {
        return MCommand(112).Comment(comment);
    }

    public GCodeWriter HostKeepAlive(int? s = null, string? comment = null) {
        return MCommand(113).Param("S", s).Comment(comment);
    }

    public GCodeWriter GetCurrentPosition(bool? d = null, bool? e = null, bool? r = null, string? comment = null) {
        return MCommand(114).Flag("D", d).Flag("E", e).Flag("R", r).Comment(comment);
    }

    public GCodeWriter FirmwareInfo(string? comment = null) {
        return MCommand(115).Comment(comment);
    }

    public GCodeWriter SetLcdMessage(string? message = null, string? comment = null) {
        return MCommand(117).Param(message).Comment(comment);
    }

    public GCodeWriter SerialPrint(bool? a1 = null, bool? e1 = null, int? pn = null, string? message = null, string? comment = null) {
        return MCommand(118).Flag("A1", a1).Flag("E1", e1).Param("Pn", pn).Param(message).Comment(comment);
    }

    public GCodeWriter EndstopStates(string? comment = null) {
        return MCommand(119).Comment(comment);
    }

    public GCodeWriter EnableEndstops(string? comment = null) {
        return MCommand(120).Comment(comment);
    }

    public GCodeWriter DisableEndstops(string? comment = null) {
        return MCommand(121).Comment(comment);
    }

    public GCodeWriter TmcDebugging(bool? e = null, bool? i = null, int? p = null, bool? s = null, bool? v = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(122).Flag("E", e).Flag("I", i).Param("P", p).Flag("S", s).Flag("V", v).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter FanTachometers(string? comment = null) {
        return MCommand(123).Comment(comment);
    }

    public GCodeWriter ParkHead(double? l = null, bool? p = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(125).Param("L", l).Param("P", p).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter Baricuda1Open(double? s = null, string? comment = null) {
        return MCommand(126).Param("S", s).Comment(comment);
    }

    public GCodeWriter Baricuda1Close(string? comment = null) {
        return MCommand(127).Comment(comment);
    }

    public GCodeWriter Baricuda2Open(double? s = null, string? comment = null) {
        return MCommand(128).Param("S", s).Comment(comment);
    }

    public GCodeWriter Baricuda2Close(string? comment = null) {
        return MCommand(129).Comment(comment);
    }

    public GCodeWriter SetBedTemperature(int? i = null, double? s = null, string? comment = null) {
        return MCommand(140).Param("I", i).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetChamberTemperature(double? s = null, string? comment = null) {
        return MCommand(141).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetLaserCoolerTemperature(double? s = null, string? comment = null) {
        return MCommand(143).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetMaterialPreset(double? b = null, double? f = null, double? h = null, int? s = null, string? comment = null) {
        return MCommand(145).Param("B", b).Param("F", f).Param("H", h).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetTemperatureUnits(bool? c = null, bool? f = null, bool? k = null, string? comment = null) {
        return MCommand(149).Flag("C", c).Flag("F", f).Flag("K", k).Comment(comment);
    }

    public GCodeWriter SetRgbwColor(int? b = null, int? i = null, int? p = null, int? r = null, int? s = null, int? u = null, int? w = null, string? comment = null) {
        return MCommand(150).Param("B", b).Param("I", i).Param("P", p).Param("R", r).Param("S", s).Param("U", u).Param("W", w).Comment(comment);
    }

    public GCodeWriter PositionAutoReport(double? s = null, string? comment = null) {
        return MCommand(154).Param("S", s).Comment(comment);
    }

    public GCodeWriter TemperatureAutoReport(double? s = null, string? comment = null) {
        return MCommand(155).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetMixFactor(double? p = null, int? s = null, string? comment = null) {
        return MCommand(163).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter SaveMix(int? s = null, string? comment = null) {
        return MCommand(164).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetMix(double? a = null, double? b = null, double? c = null, double? d = null, double? h = null, int? i = null, string? comment = null) {
        return MCommand(165).Param("A", a).Param("B", b).Param("C", c).Param("D", d).Param("H", h).Param("I", i).Comment(comment);
    }

    public GCodeWriter GradientMix(double? a = null, int? i = null, int? j = null, bool? s = null, int? t = null, double? z = null, string? comment = null) {
        return MCommand(166).Param("A", a).Param("I", i).Param("J", j).Param("S", s).Param("T", t).Param("Z", z).Comment(comment);
    }

    public GCodeWriter WaitForBedTemperature(int? i = null, double? r = null, double? s = null, string? comment = null) {
        return MCommand(190).Param("I", i).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter WaitForChamberTemperature(double? r = null, double? s = null, string? comment = null) {
        return MCommand(191).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter WaitForProbeTemperature(double? r = null, double? s = null, string? comment = null) {
        return MCommand(192).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter WaitForLaserCoolerTemperature(double? s = null, string? comment = null) {
        return MCommand(193).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetFilamentDiameter(double? d = null, double? l = null, bool? s = null, int? t = null, string? comment = null) {
        return MCommand(200).Param("D", d).Param("L", l).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter PrintMoveLimits(double? e = null, double? f = null, double? s = null, int? t = null, double? y = null, double? x = null, double? z = null, string? comment = null) {
        return MCommand(201).Param("E", e).Param("F", f).Param("S", s).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetMaxFeedRate(double? e = null, int? t = null, double? y = null, double? x = null, double? z = null, string? comment = null) {
        return MCommand(203).Param("E", e).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetStartingAcceleration(double? p = null, double? r = null, double? s = null, double? t = null, string? comment = null) {
        return MCommand(204).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter SetAdvancedSettings(double? b = null, double? e = null, double? j = null, double? s = null, double? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(205).Param("B", b).Param("E", e).Param("J", j).Param("S", s).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetHomeOffsets(double? p = null, double? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(206).Param("P", p).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetFirmwareRetraction(double? f = null, double? s = null, double? w = null, double? z = null, string? comment = null) {
        return MCommand(207).Param("F", f).Param("S", s).Param("W", w).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetFirmwareRecover(double? f = null, double? r = null, double? s = null, double? w = null, string? comment = null) {
        return MCommand(208).Param("F", f).Param("R", r).Param("S", s).Param("W", w).Comment(comment);
    }

    public GCodeWriter SetAutoRetract(bool? s = null, string? comment = null) {
        return MCommand(209).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetSoftwareEndstops(bool? s = null, string? comment = null) {
        return MCommand(211).Param("S", s).Comment(comment);
    }

    public GCodeWriter FilamentSwapParameters(double? a = null, double? b = null, double? e = null, double? f = null, double? g = null, double? l = null, double? p = null, bool? q = null, double? r = null, double? s = null, double? u = null, double? v = null, double? w = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(217).Param("A", a).Param("B", b).Param("E", e).Param("F", f).Param("G", g).Param("L", l).Param("P", p).Flag("Q", q).Param("R", r).Param("S", s).Param("U", u).Param("V", v).Param("W", w).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetHotendOffset(int? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(218).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetFeedratePercentage(bool? b = null, bool? r = null, double? s = null, string? comment = null) {
        return MCommand(220).Param("B", b).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetFeedratePercentage(double? s = null, int? t = null, string? comment = null) {
        return MCommand(221).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter WaitForPinState(int? p = null, int? s = null, string? comment = null) {
        return MCommand(226).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter TriggerCamera(double? a = null, double? b = null, double? d = null, double? f = null, double? i = null, double? j = null, double? p = null, double? r = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(240).Param("A", a).Param("B", b).Param("D", d).Param("F", f).Param("I", i).Param("J", j).Param("P", p).Param("R", r).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter LcdContrast(double? c = null, string? comment = null) {
        return MCommand(250).Param("C", c).Comment(comment);
    }

    public GCodeWriter LcdBrightness(double? b = null, string? comment = null) {
        return MCommand(256).Param("B", b).Comment(comment);
    }

    public GCodeWriter I2cSend(int? a = null, byte? b = null, bool? r = null, bool? s = null, string? comment = null) {
        return MCommand(260).Param("A", a).Param("B", b).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter I2cRequest(int? a = null, int? b = null, int? s = null, string? comment = null) {
        return MCommand(261).Param("A", a).Param("B", b).Param("S", s).Comment(comment);
    }

    public GCodeWriter ServoPosition(int? p = null, int? s = null, string? comment = null) {
        return MCommand(280).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter EditServoAngles(double? l = null, int? p = null, double? u = null, string? comment = null) {
        return MCommand(281).Param("L", l).Param("P", p).Param("U", u).Comment(comment);
    }

    public GCodeWriter DetachServo(int? p = null, string? comment = null) {
        return MCommand(281).Param("P", p).Comment(comment);
    }

    public GCodeWriter BabyStep(bool? p = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(290).Param("P", p).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter PlayTone(double? p = null, double? s = null, string? comment = null) {
        return MCommand(300).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter SetHotendPid(double? c = null, double? d = null, double? e = null, double? f = null, int? i = null, double? l = null, double? p = null, string? comment = null) {
        return MCommand(301).Param("C", c).Param("D", d).Param("E", e).Param("F", f).Param("I", i).Param("L", l).Param("P", p).Comment(comment);
    }

    public GCodeWriter ColdExtrude(bool? p = null, double? s = null, string? comment = null) {
        return MCommand(302).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter PidAutotune(int? c = null, int? d = null, int? e = null, double? s = null, bool? u = null, string? comment = null) {
        return MCommand(303).Param("C", c).Param("D", d).Param("E", e).Param("S", s).Param("U", u).Comment(comment);
    }

    public GCodeWriter SetBedPid(double? d = null, int? i = null, double? p = null, string? comment = null) {
        return MCommand(304).Param("D", d).Param("I", i).Param("P", p).Comment(comment);
    }

    public GCodeWriter UserThermistorParameters(double? b = null, double? c = null, int? p = null, double? r = null, double? t = null, string? comment = null) {
        return MCommand(305).Param("B", b).Param("C", c).Param("P", p).Param("R", r).Param("T", t).Comment(comment);
    }

    public GCodeWriter ModelPredictiveTemperatureControl(double? a = null, double? c = null, int? e = null, double? f = null, double? h = null, double? p = null, double? r = null, bool? t = null, string? comment = null) {
        return MCommand(306).Param("A", a).Param("C", c).Param("E", e).Param("F", f).Param("H", h).Param("P", p).Param("R", r).Flag("T", t).Comment(comment);
    }

    public GCodeWriter SetMicroStepping(int? b = null, int? e = null, int? s = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(350).Param("B", b).Param("E", e).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetMicrostepPins(int? b = null, int? e = null, int? s = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(351).Param("B", b).Param("E", e).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter CaseLightControl(byte? p = null, bool? s = null, string? comment = null) {
        return MCommand(355).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter ScaraThetaA(string? comment = null) {
        return MCommand(360).Comment(comment);
    }

    public GCodeWriter ScaraThetaB(string? comment = null) {
        return MCommand(361).Comment(comment);
    }

    public GCodeWriter ScaraPsiA(string? comment = null) {
        return MCommand(362).Comment(comment);
    }

    public GCodeWriter ScaraPsiB(string? comment = null) {
        return MCommand(363).Comment(comment);
    }

    public GCodeWriter ScaraPsiC(string? comment = null) {
        return MCommand(364).Comment(comment);
    }

    public GCodeWriter ActivateSolenoid(int? s = null, string? comment = null) {
        return MCommand(380).Param("S", s).Comment(comment);
    }

    public GCodeWriter DeactivateSolenoid(int? s = null, string? comment = null) {
        return MCommand(381).Param("S", s).Comment(comment);
    }

    public GCodeWriter FinishMoves(string? comment = null) {
        return MCommand(400).Comment(comment);
    }

    public GCodeWriter StowProbe(string? comment = null) {
        return MCommand(402).Comment(comment);
    }

    public GCodeWriter Mmu2FilamentType(int? e = null, int? f = null, string? comment = null) {
        return MCommand(403).Param("E", e).Param("F", f).Comment(comment);
    }

    public GCodeWriter SetFilamentDiameter(double? w = null, string? comment = null) {
        return MCommand(404).Param("W", w).Comment(comment);
    }

    public GCodeWriter SetFilamentWidthSensorOn(double? d = null, string? comment = null) {
        return MCommand(405).Param("D", d).Comment(comment);
    }

    public GCodeWriter SetFilamentWidthSensorOff(string? comment = null) {
        return MCommand(406).Comment(comment);
    }

    public GCodeWriter FilamentWidth(string? comment = null) {
        return MCommand(407).Comment(comment);
    }

    public GCodeWriter Quickstop(string? comment = null) {
        return MCommand(410).Comment(comment);
    }

    public GCodeWriter FilamentRunout(double? d = null, bool? h = null, bool? r = null, bool? s = null, string? comment = null) {
        return MCommand(412).Param("D", d).Param("H", h).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter PowerLossRecovery(bool? s = null, string? comment = null) {
        return MCommand(413).Param("S", s).Comment(comment);
    }

    public GCodeWriter BedLevellingState(bool? c = null, int? l = null, bool? s = null, int? t = null, bool? v = null, double? z = null, string? comment = null) {
        return MCommand(420).Param("C", c).Param("L", l).Param("S", s).Param("T", t).Param("V", v).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetMeshValue(bool? c = null, int? i = null, int? j = null, bool? n = null, double? q = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(421).Param("C", c).Param("I", i).Param("J", j).Param("N", n).Param("Q", q).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter XTwistCompensation(double? a = null, double? i = null, bool? r = null, int? x = null, int? z = null, string? comment = null) {
        return MCommand(423).Param("A", a).Param("I", i).Flag("R", r).Param("X", x).Param("Z", z).Comment(comment);
    }

    public GCodeWriter BacklashCompensation(double? f = null, double? s = null, double? x = null, double? y = null, double? z =null, bool? z2 = null, string? comment = null) {
        return MCommand(425).Param("F", f).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Flag("Z", z2).Comment(comment);
    }

    public GCodeWriter HomeOffsetsHere(string? comment = null) {
        return MCommand(428).Comment(comment);
    }

    public GCodeWriter PowerMonitor(bool? i = null, bool? v = null, bool? w = null, string? comment = null) {
        return MCommand(430).Param("I", i).Param("V", v).Param("W", w).Comment(comment);
    }

    public GCodeWriter CancelObjects(bool? c = null, int? p = null, int? s = null, int? t = null, int? u = null, string? comment = null) {
        return MCommand(486).Param("C", c).Param("P", p).Param("S", s).Param("T", t).Param("U", u).Comment(comment);
    }

    public GCodeWriter SaveSettings(string? comment = null) {
        return MCommand(500).Comment(comment);
    }

    public GCodeWriter RestoreSettings(string? comment = null) {
        return MCommand(501).Comment(comment);
    }

    public GCodeWriter FactoryReset(string? comment = null) {
        return MCommand(502).Comment(comment);
    }

    public GCodeWriter ReportSettings(bool? c = null, bool? s = null, string? comment = null) {
        return MCommand(502).Param("C", c).Param("S", s).Comment(comment);
    }

    public GCodeWriter ValidateEepromContents(string? comment = null) {
        return MCommand(504).Comment(comment);
    }

    public GCodeWriter LockMachine(string? comment = null) {
        return MCommand(510).Comment(comment);
    }

    public GCodeWriter UnlockMachine(string p, string? comment = null) {
        return MCommand(511).Param("P", p).Comment(comment);
    }

    public GCodeWriter SetPasscode(string p, string? s = null, string? comment = null) {
        return MCommand(512).Param("P", p).Param("S", s).Comment(comment);
    }

    public GCodeWriter AbortSdPrint(string? comment = null) {
        return MCommand(524).Comment(comment);
    }
    
    public GCodeWriter EndstopsAbortSd(bool s, string? comment = null) {
        return MCommand(540).Param("S", s).Comment(comment);
    }
    
    public GCodeWriter SetTmcSsteppingMode(bool? e = null, int? i = null, int? t = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(569).Flag("E", e).Param("I", i).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SerialBaudRate(int? b = null, int? p = null, string? comment = null) {
        return MCommand(569).Param("B", b).Param("P", p).Comment(comment);
    }

    public GCodeWriter FilamentChange(bool? b = null, double? e = null, double? l = null, bool? r = null, int? t = null, double? u = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(600).Param("B", b).Param("E", e).Param("L", l).Param("R", r).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter ConfigureFilamentChange(double? l = null, int? t = null, double? u = null, string? comment = null) {
        return MCommand(603).Param("L", l).Param("T", t).Param("U", u).Comment(comment);
    }

    public GCodeWriter MultiNozzleMode(double? r = null, int? s = null, double? x = null, string? comment = null) {
        return MCommand(605).Param("R", r).Param("S", s).Param("X", x).Comment(comment);
    }

    public GCodeWriter DeltaConfiguration(double? a = null, double? b = null, double? c = null, double? h = null, double? l = null, double? r = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(665).Param("A", a).Param("B", b).Param("C", c).Param("H", h).Param("L", l).Param("R", r).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter ScaraConfiguration(double? a = null, double? b = null, double? p = null, double? s = null, double? t = null, double? x = null, double? y = null, string? comment = null) {
        return MCommand(665).Param("A", a).Param("B", b).Param("P", p).Param("S", s).Param("T", t).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter SetDeltaEndstopAdjustments(double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(666).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetDualEndstopOffsets(double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(666).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter DuetSmartEffectorSensitivity(bool? r = null, double? s = null, string? comment = null) {
        return MCommand(672).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter LoadFilament(double? l = null, int? t = null, double? z = null, string? comment = null) {
        return MCommand(701).Param("L", l).Param("T", t).Param("Z", z).Comment(comment);
    }

    public GCodeWriter UnloadFilament(int? t = null, double? u = null, double? z = null, string? comment = null) {
        return MCommand(702).Param("T", t).Param("U", u).Param("Z", z).Comment(comment);
    }

    public GCodeWriter ControllerFanSettings(bool? a = null, double? d = null, double? i = null, bool? r = null, double? s = null, string? comment = null) {
        return MCommand(710).Param("A", a).Param("D", d).Param("I", i).Param("R", r).Param("S", s).Comment(comment);
    }

    public GCodeWriter RepeatMarker(int? l = null, string? comment = null) {
        return MCommand(810).Param("L", l).Comment(comment);
    }

    public GCodeWriter GCodeMacro0(string? s = null, string? comment = null) {
        return MCommand(810).Param(s).Comment(comment);
    }

    public GCodeWriter GCodeMacro1(string? s = null, string? comment = null) {
        return MCommand(811).Param(s).Comment(comment);
    }

    public GCodeWriter GCodeMacro2(string? s = null, string? comment = null) {
        return MCommand(812).Param(s).Comment(comment);
    }

    public GCodeWriter GCodeMacro3(string? s = null, string? comment = null) {
        return MCommand(813).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro4(string? s = null, string? comment = null) {
        return MCommand(814).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro5(string? s = null, string? comment = null) {
        return MCommand(815).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro6(string? s = null, string? comment = null) {
        return MCommand(816).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro7(string? s = null, string? comment = null) {
        return MCommand(817).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro8(string? s = null, string? comment = null) {
        return MCommand(818).Param(s).Comment(comment);
    }
    
    public GCodeWriter GCodeMacro9(string? s = null, string? comment = null) {
        return MCommand(819).Param(s).Comment(comment);
    }

    public GCodeWriter XyzProbeOffset(double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(851).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter BedSkewCompensation(double? i = null, double? j = null, double? k = null, double? s = null, string? comment = null) {
        return MCommand(851).Param("I", i).Param("J", j).Param("K", k).Param("S", s).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersReportPosition(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(860).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersReportStatus(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(861).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersAxisContinuity(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(862).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersStepsCalibration(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(863).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersChangePosition(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(864).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersCheckPosition(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(865).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersErrorCount(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(866).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersEnableDisable(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(867).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersReportErrorCorrection(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(868).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter I2cPostionEncodersError(int? e = null, int? i = null, bool? o = null, int? p = null, bool? r = null, int? s = null, double? t = null, bool? u = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(869).Param("E", e).Param("I", i).Param("O", o).Param("P", p).Param("R", r).Param("S", s).Param("T", t).Param("U", u).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter ProbeTemperatureConfig(bool? b = null, bool? e = null, bool? i = null, bool? p = null, bool? r = null, double? v = null, string? comment = null) {
        return MCommand(871).Param("B", b).Param("E", e).Param("I", i).Param("P", p).Param("R", r).Param("V", v).Comment(comment);
    }

    public GCodeWriter HandlePromptResponse(string? s = null, string? comment = null) {
        return MCommand(876).Param("S", s).Comment(comment);
    }

    public GCodeWriter LinearAdvanceFactor(double? k = null, double? l = null, int? s = null, int? t = null, string? comment = null) {
        return MCommand(900).Param("K", k).Param("L", l).Param("S", s).Param("T", t).Comment(comment);
    }

    public GCodeWriter StepperMotorCurrent(double? e = null, int? i = null, int? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(906).Param("E", e).Param("I", i).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetMotorCurrent(double? b = null, double? c = null, double? d = null, double? e = null, double? s = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(907).Param("B", b).Param("C", c).Param("D", d).Param("E", e).Param("S", s).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter SetTrimpotPins(int? e = null, double? s = null, string? comment = null) {
        return MCommand(908).Param("E", e).Param("S", s).Comment(comment);
    }

    public GCodeWriter DacPrintValues(string? comment = null) {
        return MCommand(909).Comment(comment);
    }

    public GCodeWriter CommitDacToEeprom(string? comment = null) {
        return MCommand(910).Comment(comment);
    }

    public GCodeWriter TmcOtPreWarnCondition(string? comment = null) {
        return MCommand(911).Comment(comment);
    }

    public GCodeWriter ClearTmcOtPreWarn(int? e = null, int? i = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(912).Param("E", e).Param("I", i).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter SetHybridThresholdSpeed(bool? e = null, int? i = null, int? t = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(913).Flag("E", e).Param("I", i).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter TmcBumpSensitivity(int? i = null, int? x = null, int? y = null, int? z = null, string? comment = null) {
        return MCommand(914).Param("I", i).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter TmcZAxisCalibration(double? s = null, double? z = null, string? comment = null) {
        return MCommand(915).Param("S", s).Param("Z", z).Comment(comment);
    }

    public GCodeWriter L6474ThermalWarningTest(double? d = null, double? e = null, double? f = null, int? j = null, double? k = null, double? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(916).Param("D", d).Param("E", e).Param("F", f).Param("J", j).Param("K", k).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter L6474OvercurrentWarningTest(double? e = null, double? f = null, double? i = null, int? j = null, double? k = null, double? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(917).Param("E", e).Param("F", f).Param("I", i).Param("J", j).Param("K", k).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter L6474SpeedWarningTest(double? e = null, double? i = null, int? j = null, double? k = null, double? m = null, double? t = null, double? x = null, double? y = null, double? z = null, string? comment = null) {
        return MCommand(918).Param("E", e).Param("I", i).Param("J", j).Param("K", k).Param("M", m).Param("T", t).Param("X", x).Param("Y", y).Param("Z", z).Comment(comment);
    }

    public GCodeWriter TmcChopperTiming(bool? a = null, bool? b = null, bool? c = null, int? i = null, int? o = null, int? p = null, int? s = null, int? t = null, bool? u = null, bool? v = null, bool? w = null, bool? x = null, bool? y = null, bool? z = null, string? comment = null) {
        return MCommand(919).Flag("A", a).Flag("B", b).Flag("C", c).Param("I", i).Param("O", o).Param("P", p).Param("S", s).Param("T", t).Flag("U", u).Flag("V", v).Flag("W", w).Flag("X", x).Flag("Y", y).Flag("Z", z).Comment(comment);
    }

    public GCodeWriter StartSdLogging(string filename, string? comment = null) {
        return MCommand(928).Param(filename).Comment(comment);
    }

    public GCodeWriter MagneticParkingExtruder(double? c = null, double? d = null, double? h = null, double? i = null, double? j = null, double? l = null, double? r = null, string? comment = null) {
        return MCommand(951).Param("C", c).Param("D", d).Param("H", h).Param("I", i).Param("J", j).Param("L", l).Param("R", r).Comment(comment);
    }

    public GCodeWriter BackupSpiFlashToSd(string? comment = null) {
        return MCommand(993).Comment(comment);
    }

    public GCodeWriter LoadBackupFromSdToSpiFlash(string? comment = null) {
        return MCommand(994).Comment(comment);
    }

    public GCodeWriter TouchScreenCalibration(string? comment = null) {
        return MCommand(995).Comment(comment);
    }

    public GCodeWriter FirmwareUpgrade(string? comment = null) {
        return MCommand(997).Comment(comment);
    }

    public GCodeWriter StopRestart(bool? s = null, string? comment = null) {
        return MCommand(999).Param("S", s).Comment(comment);
    }

    public GCodeWriter Max7219Control(int? c = null, int? d = null, bool? f = null, bool? i = null, bool? p = null, int? r = null, int? u = null, int? v = null, int? x = null, int? y = null, string? comment = null) {
        return MCommand(7219).Param("C", c).Param("D", d).Param("F", f).Param("I", i).Param("P", p).Param("R", r).Param("U", u).Param("V", v).Param("X", x).Param("Y", y).Comment(comment);
    }

    public GCodeWriter SelectTool0(string? comment = null) {
        return TCommand(0).Comment(comment);
    }

    public GCodeWriter SelectTool1(string? comment = null) {
        return TCommand(1).Comment(comment);
    }

    public GCodeWriter SelectTool2(string? comment = null) {
        return TCommand(2).Comment(comment);
    }

    public GCodeWriter SelectTool3(string? comment = null) {
        return TCommand(3).Comment(comment);
    }

    public GCodeWriter SelectTool4(string? comment = null) {
        return TCommand(4).Comment(comment);
    }

    public GCodeWriter SelectTool5(string? comment = null) {
        return TCommand(5).Comment(comment);
    }

    public GCodeWriter SelectTool6(string? comment = null) {
        return TCommand(6).Comment(comment);
    }

    private GCodeWriter GCommand(int command) {
        return Write("G").Write(command);
    }

    private GCodeWriter MCommand(int command) {
        return Write("M").Write(command);
    } 
    
    private GCodeWriter TCommand(int command) {
        return Write("T").Write(command);
    } 

    private GCodeWriter SubCommand(int subCommand) {
        return Write(".").Write(subCommand);
    }

    private GCodeWriter Param(string? value) {
        if (value is null) {
            return this;
        }

        return Write($" {value}");
    }

    private GCodeWriter Param(string name, string? value) {
        if (value is null) {
            return this;
        }

        return Write($" {name}{value}");
    }

    private GCodeWriter Param(string name, double? value) {
        if (value is null) {
            return this;
        }

        return Write($" {name}{value.Value:0.###}");
    }

    private GCodeWriter Param(string name, int? value) {
        if (value is null) {
            return this;
        }

        return Write($" {name}{value.Value:0}");
    }

    private GCodeWriter Param(string name, bool? value) {
        if (value is null) {
            return this;
        }

        if (value.Value) {
            return Write($" {name}1");
        } else {
            return Write($" {name}0");
        }
    }
       
    private GCodeWriter Flag(string name, bool? flag) {
        if (flag is null) {
            return this;
        }

        if (flag.Value) {
            Write($" {name}");
        }

        return this;
    }

    private GCodeWriter Write(int i) {
        return Write(i.ToString());
    }

    private GCodeWriter Write(string s) {
        _writer.Write(s);
        _startOfLine = false;
        return this;
    }

    public GCodeWriter Comment(string? comment) {
        if (comment is not null) {
            if (!_startOfLine) {
                _writer.Write(" ");
            }

            _writer.Write(";");
            _writer.WriteLine(comment);
        } else {
            _writer.WriteLine();
        }

        _startOfLine = true;

        return this;
    }
}
