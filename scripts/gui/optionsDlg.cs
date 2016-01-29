//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------


/// Returns true if the current quality settings equal
/// this graphics quality level.
function GraphicsQualityLevel::isCurrent( %this )
{
   // Test each pref to see if the current value
   // equals our stored value.
   
   for ( %i=0; %i < %this.count(); %i++ )
   {
      %pref = %this.getKey( %i );
      %value = %this.getValue( %i );
      
      if ( getVariable( %pref ) !$= %value )
         return false;
   }
   
   return true;
}

/// Applies the graphics quality settings and calls 
/// 'onApply' on itself or its parent group if its 
/// been overloaded.
function GraphicsQualityLevel::apply( %this )
{
   for ( %i=0; %i < %this.count(); %i++ )
   {
      %pref = %this.getKey( %i );
      %value = %this.getValue( %i );
      setVariable( %pref, %value );
   }
   
   // If we have an overloaded onApply method then
   // call it now to finalize the changes.
   if ( %this.isMethod( "onApply" ) )   
      %this.onApply();
   else
   {
      %group = %this.getGroup();      
      if ( isObject( %group ) && %group.isMethod( "onApply" ) )
         %group.onApply( %this );
   }   
}

function GraphicsQualityPopup::init( %this, %qualityGroup )
{
   assert( isObject( %this ) );
   assert( isObject( %qualityGroup ) );
            
   // Clear the existing content first.   
   %this.clear();
    
   // Fill it.
   %select = -1;
   for ( %i=0; %i < %qualityGroup.getCount(); %i++ )
   {
      %level = %qualityGroup.getObject( %i );
      if ( %level.isCurrent() )
         %select = %i;
         
      %this.add( %level.getInternalName(), %i );
   }
   
   // Setup a default selection.
   if ( %select == -1 )
      %this.setText( "Custom" );
   else
      %this.setSelected( %select );      
}

function GraphicsQualityPopup::apply( %this, %qualityGroup, %testNeedApply )
{
   assert( isObject( %this ) );
   assert( isObject( %qualityGroup ) );
   
   %quality = %this.getText();
   
   %index = %this.findText( %quality );
   if ( %index == -1 )
      return false;

   %level = %qualityGroup.getObject( %index );
   if ( isObject( %level ) && !%level.isCurrent() )
   {
      if ( %testNeedApply )
         return true;

      %level.apply();
   }
   
   return false;
}

function OptionsDlg::setPane(%this, %pane)
{
   %this-->OptAudioPane.setVisible(false);
   %this-->OptGraphicsPane.setVisible(false);
   %this-->OptAdvGraphicsPane.setVisible(false);
   %this-->OptNetworkPane.setVisible(false);
   %this-->OptControlsPane.setVisible(false);
   %this-->OptGeneralPane.setVisible(false);
   %this-->OptServerPane.setVisible(false);
   
   %this.findObjectByInternalName( "Opt" @ %pane @ "Pane", true ).setVisible(true);
   
   %this.fillRemapList();
      
   // Update the state of the apply button.
   %this._updateApplyState();
}

function OptionsDlg::onWake(%this)
{
   if ( isFunction("getWebDeployment") && getWebDeployment() )
   {
      // Cannot enable full screen under web deployment
      %this-->OptGraphicsFullscreenToggle.setStateOn( false );
      %this-->OptGraphicsFullscreenToggle.setVisible( false );
   }
   else
   {
      %this-->OptGraphicsFullscreenToggle.setStateOn( Canvas.isFullScreen() );
   }
   %this-->OptGraphicsVSyncToggle.setStateOn( !$pref::Video::disableVerticalSync );
   
   
   //%this-->Tgl_1.setStateOn( $pref::Interior::VertexLighting );
   %this-->Tgl_2.setStateOn( $pref::Water::disableTrueReflections );
   %this-->Tgl_3.setStateOn( $pref::Video::disablePixSpecular );
   %this-->Tgl_4.setStateOn( $pref::Video::disableParallaxMapping );
   %this-->Tgl_5.setStateOn( $pref::Video::disableNormalMapping );
   %this-->Tgl_6.setStateOn( $pref::Video::disableCubemapping );
   %this-->Tgl_7.setStateOn( $pref::Decals::enabled );
   %this-->Tgl_8.setStateOn( $pref::Shadows::disable );
   %this-->Tgl_9.setStateOn( $pref::enablePostEffects );
   
   //%this-->Tgl_10.setStateOn( $pref::LightManager::Enable::AA );
   %this-->Tgl_11.setStateOn( $pref::LightManager::Enable::HDR );
   %this-->Tgl_12.setStateOn( $pref::LightManager::Enable::SSAO );
   %this-->Tgl_13.setStateOn( $pref::LightManager::Enable::LightRay );
   %this-->Tgl_14.setStateOn( $pref::LightManager::Enable::DOF );
   
   //%this-->Tgl_DisplayMaster.setStateOn($pref::Net::DisplayOnMaster);


   OptionsDlg.initResMenu();
   %resSelId = OptionsDlg-->OptGraphicsResolutionMenu.findText( _makePrettyResString( $pref::Video::mode ) );
   if( %resSelId != -1 )
      OptionsDlg-->OptGraphicsResolutionMenu.setSelected( %resSelId );
   
   OptGraphicsDriverMenu.clear();
   
   %buffer = getDisplayDeviceList();
   %count = getFieldCount( %buffer );   
   for(%i = 0; %i < %count; %i++)
      OptGraphicsDriverMenu.add(getField(%buffer, %i), %i);

   %selId = OptGraphicsDriverMenu.findText( getDisplayDeviceInformation() );
	if ( %selId == -1 )
		OptGraphicsDriverMenu.setFirstSelected();
   else
	   OptGraphicsDriverMenu.setSelected( %selId );

   // Setup the graphics quality dropdown menus.
   %this-->OptMeshQualityPopup.init( MeshQualityGroup );
   %this-->OptTextureQualityPopup.init( TextureQualityGroup );
   %this-->OptLightingQualityPopup.init( LightingQualityGroup );
   %this-->OptShaderQualityPopup.init( ShaderQualityGroup );
   %this-->OptEffectQualityPopup.init( EffectQualityGroup );

   // Setup the anisotropic filtering menu.
   %ansioCtrl = %this-->OptAnisotropicPopup;
   %ansioCtrl.clear();
   %ansioCtrl.add( "Off", 0 );
   %ansioCtrl.add( "4X", 4 );
   %ansioCtrl.add( "8X", 8 );
   %ansioCtrl.add( "16X", 16 );
   %ansioCtrl.setSelected( $pref::Video::defaultAnisotropy, false );
            
   // set up the Refresh Rate menu.
   %refreshMenu = %this-->OptRefreshSelectMenu;
   %refreshMenu.clear();
   // %refreshMenu.add("Auto", 60);
   %refreshMenu.add("60", 60);
   %refreshMenu.add("75", 75);
   %refreshMenu.setSelected( getWord( $pref::Video::mode, $WORD::REFRESH ) );
   
   // Audio
   //OptAudioHardwareToggle.setStateOn($pref::SFX::useHardware);
   //OptAudioHardwareToggle.setActive( true );
   
   %this-->OptAudioVolumeMaster.setValue( $pref::SFX::masterVolume );
   %this-->OptAudioVolumeShell.setValue( $pref::SFX::channelVolume[ $GuiAudioType] );
   %this-->OptAudioVolumeSim.setValue( $pref::SFX::channelVolume[ $SimAudioType ] );
   %this-->OptAudioVolumeMusic.setValue( $pref::SFX::channelVolume[ $MusicAudioType ] );
   
   OptAudioProviderList.clear();
   %buffer = sfxGetAvailableDevices();
   %count = getRecordCount( %buffer );   
   for(%i = 0; %i < %count; %i++)
   {
      %record = getRecord(%buffer, %i);
      %provider = getField(%record, 0);
      
      if ( OptAudioProviderList.findText( %provider ) == -1 )
            OptAudioProviderList.add( %provider, %i );
   }
   
   OptAudioProviderList.sort();

   %selId = OptAudioProviderList.findText($pref::SFX::provider);
	if ( %selId == -1 )
		OptAudioProviderList.setFirstSelected();
   else
	   OptAudioProviderList.setSelected( %selId );
	   
   // Populate the Anti-aliasing popup.
   %aaMenu = %this-->OptAAQualityPopup;
   %aaMenu.clear();
   %aaMenu.Add( "Off", 0 );
   %aaMenu.Add( "1x", 1 );
   %aaMenu.Add( "2x", 2 );
   %aaMenu.Add( "4x", 4 );
   %aaMenu.setSelected( getWord( $pref::Video::mode, $WORD::AA ) );
   
   OptMouseSensitivity.value = $pref::Input::LinkMouseSensitivity;
      
   // Set the graphics pane to start.
   %this-->OptGraphicsButton.performClick();
}

function OptionsDlg::onSleep(%this)
{
   // write out the control config into the rw/config.cs file
   moveMap.save( GetUserHomeDirectory() @ "/My Games/" @ $AppName @ "/bindings.config.cs" );
}

function OptGraphicsDriverMenu::onSelect( %this, %id, %text )
{
	// Attempt to keep the same resolution settings:
	%resMenu = OptionsDlg-->OptGraphicsResolutionMenu;	
   %currRes = %resMenu.getText();
   
   // If its empty the use the current.
   if ( %currRes $= "" )
      %currRes = _makePrettyResString( Canvas.getVideoMode() );
                  
	// Fill the resolution list.
	optionsDlg.initResMenu();

	// Try to select the previous settings:
	%selId = %resMenu.findText( %currRes );
	if ( %selId == -1 )	
	   %selId = 0;	   
   %resMenu.setSelected( %selId );
	
	OptionsDlg._updateApplyState();
}

function _makePrettyResString( %resString )
{
   %width = getWord( %resString, $WORD::RES_X );
   %height = getWord( %resString, $WORD::RES_Y );
   
   %aspect = %width / %height;
   %aspect = mRound( %aspect * 100 ) * 0.01;            
   
   switch$( %aspect )
   {
      case "1.33":
         %aspect = "4:3";
      case "1.78":
         %aspect = "16:9";
      default:
         %aspect = "";
   }
   
   %outRes = %width @ " x " @ %height;
   if ( %aspect !$= "" )
      %outRes = %outRes @ "  (" @ %aspect @ ")";
      
   return %outRes;   
}

function OptionsDlg::initResMenu( %this )
{
   // Clear out previous values
   %resMenu = %this-->OptGraphicsResolutionMenu;	   
   %resMenu.clear();
   
   // If we are in a browser then we can't change our resolution through
   // the options dialog
   if (getWebDeployment())
   {
      %count = 0;
      %currRes = getWords(Canvas.getVideoMode(), $WORD::RES_X, $WORD::RES_Y);
      %resMenu.add(%currRes, %count);
      %count++;

      return;
   }
   
   // Loop through all and add all valid resolutions
   %count = 0;
   %resCount = Canvas.getModeCount();
   for (%i = 0; %i < %resCount; %i++)
   {
      %testResString = Canvas.getMode( %i );
      %testRes = _makePrettyResString( %testResString );
                     
      // Only add to list if it isn't there already.
      if (%resMenu.findText(%testRes) == -1)
      {
         %resMenu.add(%testRes, %i);
         %count++;
      }
   }
   
   %resMenu.sort();
}

function OptionsDlg::applyGraphics( %this, %testNeedApply )
{
	%newAdapter    = OptGraphicsDriverMenu.getText();
	%numAdapters   = GFXInit::getAdapterCount();
	%newDevice     = $pref::Video::displayDevice;
							
	for( %i = 0; %i < %numAdapters; %i ++ )
	   if( GFXInit::getAdapterName( %i ) $= %newAdapter )
	   {
	      %newDevice = GFXInit::getAdapterType( %i );
	      break;
	   }
	   
   // Change the device.
   if ( %newDevice !$= $pref::Video::displayDevice )
   {
      if ( %testNeedApply )
         return true;
         
      $pref::Video::displayDevice = %newDevice;
      if( %newAdapter !$= getDisplayDeviceInformation() )
         MessageBoxOK( "Change requires restart", "Please restart the game for a display device change to take effect." );
   }

   // Gather the new video mode.
   if ( isFunction("getWebDeployment") && getWebDeployment() )
   {
      // Under web deployment, we use the custom resolution rather than a Canvas
      // defined one.
      %newRes = %this-->OptGraphicsResolutionMenu.getText();
   }
   else
   {
	   %newRes = getWords( Canvas.getMode( %this-->OptGraphicsResolutionMenu.getSelected() ), $WORD::RES_X, $WORD::RES_Y ); 
   }
	%newBpp        = 32; // ... its not 1997 anymore.
	%newFullScreen = %this-->OptGraphicsFullscreenToggle.getValue() ? "true" : "false";
	%newRefresh    = %this-->OptRefreshSelectMenu.getSelected();
	%newVsync = !%this-->OptGraphicsVSyncToggle.getValue();	
	%newFSAA = %this-->OptAAQualityPopup.getSelected();

   // Under web deployment we can't be full screen.
   if ( isFunction("getWebDeployment") && getWebDeployment() )
   {
      %newFullScreen = false;
   }
   else if ( %newFullScreen $= "false" )
	{
      // If we're in windowed mode switch the fullscreen check
      // if the resolution is bigger than the desktop.
      %deskRes    = getDesktopResolution();      
      %deskResX   = getWord(%deskRes, $WORD::RES_X);
      %deskResY   = getWord(%deskRes, $WORD::RES_Y);
	   if (  getWord( %newRes, $WORD::RES_X ) > %deskResX || 
	         getWord( %newRes, $WORD::RES_Y ) > %deskResY )
      {
         %newFullScreen = "true";
         %this-->OptGraphicsFullscreenToggle.setStateOn( true );
      }
	}

   // Build the final mode string.
	%newMode = %newRes SPC %newFullScreen SPC %newBpp SPC %newRefresh SPC %newFSAA;
	
   // Change the video mode.   
   if (  %newMode !$= $pref::Video::mode || 
         %newVsync != $pref::Video::disableVerticalSync )
   {
      if ( %testNeedApply )
         return true;

      $pref::Video::mode = %newMode;
      $pref::Video::disableVerticalSync = %newVsync;      
      configureCanvas();
   }
   
   // Test and apply the graphics settings.
   if ( %this-->OptMeshQualityPopup.apply( MeshQualityGroup, %testNeedApply ) ) return true;            
   if ( %this-->OptTextureQualityPopup.apply( TextureQualityGroup, %testNeedApply ) ) return true;                       
   if ( %this-->OptLightingQualityPopup.apply( LightingQualityGroup, %testNeedApply ) ) return true;            
   if ( %this-->OptShaderQualityPopup.apply( ShaderQualityGroup, %testNeedApply ) ) return true;   
   if ( %this-->OptEffectQualityPopup.apply( EffectQualityGroup, %testNeedApply ) ) return true;   

   // Check the anisotropic filtering.   
   %level = %this-->OptAnisotropicPopup.getSelected();
   if ( %level != $pref::Video::defaultAnisotropy )
   {
      if ( %testNeedApply )
         return true;
                                 
      $pref::Video::defaultAnisotropy = %level;
   }
   
   // If we're applying the state then recheck the 
   // state to update the apply button.
   if ( !%testNeedApply )
      %this._updateApplyState();
      
   return false;
}

function OptionsDlg::_updateApplyState( %this )
{
   %applyCtrl = %this-->Apply;
   %graphicsPane = %this-->OptGraphicsPane;
         
   assert( isObject( %applyCtrl ) );
   assert( isObject( %graphicsPane ) );

   %applyCtrl.active = %graphicsPane.isVisible() && %this.applyGraphics( true );   
}

function OptionsDlg::_autoDetectQuality( %this )
{
   %msg = GraphicsQualityAutodetect();
   %this.onWake();
   
   if ( %msg !$= "" )
   {
      MessageBoxOK( "Notice", %msg );
   }
}

function restoreDefaultMappings()
{
   moveMap.delete();
   exec( "scripts/client/default.bind.cs" );
   optionsDlg.fillRemapList();
}

function getMapDisplayName( %device, %action )
{
	if ( %device $= "keyboard" )
		return( %action );		
	else if ( strstr( %device, "mouse" ) != -1 )
	{
		// Substitute "mouse" for "button" in the action string:
		%pos = strstr( %action, "button" );
		if ( %pos != -1 )
		{
			%mods = getSubStr( %action, 0, %pos );
			%object = getSubStr( %action, %pos, 1000 );
			%instance = getSubStr( %object, strlen( "button" ), 1000 );
			return( %mods @ "mouse" @ ( %instance + 1 ) );
		}
		else
			error( "Mouse input object other than button passed to getDisplayMapName!" );
	}
	else if ( strstr( %device, "joystick" ) != -1 )
	{
		// Substitute "joystick" for "button" in the action string:
		%pos = strstr( %action, "button" );
		if ( %pos != -1 )
		{
			%mods = getSubStr( %action, 0, %pos );
			%object = getSubStr( %action, %pos, 1000 );
			%instance = getSubStr( %object, strlen( "button" ), 1000 );
			return( %mods @ "joystick" @ ( %instance + 1 ) );
		}
		else
	   { 
	      %pos = strstr( %action, "pov" );
         if ( %pos != -1 )
         {
            %wordCount = getWordCount( %action );
            %mods = %wordCount > 1 ? getWords( %action, 0, %wordCount - 2 ) @ " " : "";
            %object = getWord( %action, %wordCount - 1 );
            switch$ ( %object )
            {
               case "upov":   %object = "POV1 up";
               case "dpov":   %object = "POV1 down";
               case "lpov":   %object = "POV1 left";
               case "rpov":   %object = "POV1 right";
               case "upov2":  %object = "POV2 up";
               case "dpov2":  %object = "POV2 down";
               case "lpov2":  %object = "POV2 left";
               case "rpov2":  %object = "POV2 right";
               default:       %object = "??";
            }
            return( %mods @ %object );
         }
         else
            error( "Unsupported Joystick input object passed to getDisplayMapName!" );
      }
	}
		
	return( "??" );		
}

function buildFullMapString( %index )
{
   %name       = $RemapName[%index];
   %cmd        = $RemapCmd[%index];

   %temp = moveMap.getBinding( %cmd );
   if ( %temp $= "" )
      return %name TAB "";

   %mapString = "";

   %count = getFieldCount( %temp );
   for ( %i = 0; %i < %count; %i += 2 )
   {
      if ( %mapString !$= "" )
         %mapString = %mapString @ ", ";

      %device = getField( %temp, %i + 0 );
      %object = getField( %temp, %i + 1 );
      %mapString = %mapString @ getMapDisplayName( %device, %object );
   }

   return %name TAB %mapString; 
}

function OptionsDlg::fillRemapList( %this )
{
   %remapList = %this-->OptRemapList;
   
	%remapList.clear();
   for ( %i = 0; %i < $RemapCount; %i++ )
      %remapList.addRow( %i, buildFullMapString( %i ) );
}

function OptionsDlg::doRemap( %this )
{
   %remapList = %this-->OptRemapList;
   
	%selId = %remapList.getSelectedId();
   %name = $RemapName[%selId];

	RemapDlg-->OptRemapText.setValue( "Re-bind \"" @ %name @ "\" to..." );
	OptRemapInputCtrl.index = %selId;
	Canvas.pushDialog( RemapDlg );
}

function redoMapping( %device, %action, %cmd, %oldIndex, %newIndex )
{
	//%actionMap.bind( %device, %action, $RemapCmd[%newIndex] );
	moveMap.bind( %device, %action, %cmd );
	
   %remapList = %this-->OptRemapList;
	%remapList.setRowById( %oldIndex, buildFullMapString( %oldIndex ) );
	%remapList.setRowById( %newIndex, buildFullMapString( %newIndex ) );
}

function findRemapCmdIndex( %command )
{
	for ( %i = 0; %i < $RemapCount; %i++ )
	{
		if ( %command $= $RemapCmd[%i] )
			return( %i );			
	}
	return( -1 );	
}

/// This unbinds actions beyond %count associated to the
/// particular moveMap %commmand.
function unbindExtraActions( %command, %count )
{
   %temp = moveMap.getBinding( %command );
   if ( %temp $= "" )
      return;

   %count = getFieldCount( %temp ) - ( %count * 2 );
   for ( %i = 0; %i < %count; %i += 2 )
   {
      %device = getField( %temp, %i + 0 );
      %action = getField( %temp, %i + 1 );
      
      moveMap.unbind( %device, %action );
   }
}

function OptRemapInputCtrl::onInputEvent( %this, %device, %action )
{
   //error( "** onInputEvent called - device = " @ %device @ ", action = " @ %action @ " **" );
   Canvas.popDialog( RemapDlg );

   // Test for the reserved keystrokes:
   if ( %device $= "keyboard" )
   {
      // Cancel...
      if ( %action $= "escape" )
      {
         // Do nothing...
         return;
      }
   }

   %cmd  = $RemapCmd[%this.index];
   %name = $RemapName[%this.index];

   // Grab the friendly display name for this action
   // which we'll use when prompting the user below.
   %mapName = getMapDisplayName( %device, %action );
   
   // Get the current command this action is mapped to.
   %prevMap = moveMap.getCommand( %device, %action );

   // If nothing was mapped to the previous command 
   // mapping then it's easy... just bind it.
   if ( %prevMap $= "" )
   {
      unbindExtraActions( %cmd, 1 );
      moveMap.bind( %device, %action, %cmd );
      optionsDlg-->OptRemapList.setRowById( %this.index, buildFullMapString( %this.index ) );
      return;
   }

   // If the previous command is the same as the 
   // current then they hit the same input as what
   // was already assigned.
   if ( %prevMap $= %cmd )
   {
      unbindExtraActions( %cmd, 0 );
      moveMap.bind( %device, %action, %cmd );
      optionsDlg-->OptRemapList.setRowById( %this.index, buildFullMapString( %this.index ) );
      return;   
   }

   // Look for the index of the previous mapping.
   %prevMapIndex = findRemapCmdIndex( %prevMap );
   
   // If we get a negative index then the previous 
   // mapping was to an item that isn't included in
   // the mapping list... so we cannot unmap it.
   if ( %prevMapIndex == -1 )
   {
      MessageBoxOK( "Remap Failed", "\"" @ %mapName @ "\" is already bound to a non-remappable command!" );
      return;
   }

   // Setup the forced remapping callback command.
   %callback = "redoMapping(" @ %device @ ", \"" @ %action @ "\", \"" @
                              %cmd @ "\", " @ %prevMapIndex @ ", " @ %this.index @ ");";
   
   // Warn that we're about to remove the old mapping and
   // replace it with another.
   %prevCmdName = $RemapName[%prevMapIndex];
   MessageBoxYesNo( "Warning",
      "\"" @ %mapName @ "\" is already bound to \""
      @ %prevCmdName @ "\"!\nDo you wish to replace this mapping?",
       %callback, "" );
}

$AudioTestHandle = 0;
// Description to use for playing the volume test sound.  This isn't
// played with the description of the channel that has its volume changed
// because we know nothing about the playback state of the channel.  If it
// is paused or stopped, the test sound would not play then.
$AudioTestDescription = new SFXDescription()
{
   sourceGroup = AudioChannelMaster;
};

function OptAudioUpdateMasterVolume( %volume )
{
   if( %volume == $pref::SFX::masterVolume )
      return;
      
   sfxSetMasterVolume( %volume );
   $pref::SFX::masterVolume = %volume;
   
   if( !isObject( $AudioTestHandle ) )
      $AudioTestHandle = sfxPlayOnce( AudioChannel, "art/sound/ui/volumeTest.wav" );
}

function OptAudioUpdateChannelVolume( %description, %volume )
{
   %channel = sfxGroupToOldChannel( %description.sourceGroup );
   
   if( %volume == $pref::SFX::channelVolume[ %channel ] )
      return;

   sfxSetChannelVolume( %channel, %volume );
   $pref::SFX::channelVolume[ %channel ] = %volume;
   
   if( !isObject( $AudioTestHandle ) )
   {
      $AudioTestDescription.volume = %volume;
      $AudioTestHandle = sfxPlayOnce( $AudioTestDescription, "art/sound/ui/volumeTest.wav" );
   }
}

function OptAudioProviderList::onSelect( %this, %id, %text )
{
   // Skip empty provider selections.   
   if ( %text $= "" )
      return;
      
   $pref::SFX::provider = %text;
   OptAudioDeviceList.clear();
   
   %buffer = sfxGetAvailableDevices();
   %count = getRecordCount( %buffer );   
   for(%i = 0; %i < %count; %i++)
   {
      %record = getRecord(%buffer, %i);
      %provider = getField(%record, 0);
      %device = getField(%record, 1);
      
      if (%provider !$= %text)
         continue;
            
       if ( OptAudioDeviceList.findText( %device ) == -1 )
            OptAudioDeviceList.add( %device, %i );
   }

   // Find the previous selected device.
   %selId = OptAudioDeviceList.findText($pref::SFX::device);
   if ( %selId == -1 )
      OptAudioDeviceList.setFirstSelected();
   else
   OptAudioDeviceList.setSelected( %selId );
}

function OptAudioDeviceList::onSelect( %this, %id, %text )
{
   // Skip empty selections.
   if ( %text $= "" )
      return;
      
   $pref::SFX::device = %text;
   
   if ( !sfxCreateDevice(  $pref::SFX::provider, 
                           $pref::SFX::device, 
                           $pref::SFX::useHardware,
                           -1 ) )                              
      error( "Unable to create SFX device: " @ $pref::SFX::provider 
                                             SPC $pref::SFX::device 
                                             SPC $pref::SFX::useHardware );                                             
}

function OptMouseSetSensitivity(%value)  
{  
   $pref::Input::LinkMouseSensitivity = %value;  
}  



//-----------------------------------------------------------------------------
function Tgl_9::onAction(%this)
{
   if ( %this.getValue() )
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:PostFX Enabled" );
      }
      
      PostFXManager.settingsSetEnabled(true);
      $pref::LightManager::Enable = "1";
   }
   else
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:PostFX Disabled" );
      }
      
      PostFXManager.settingsSetEnabled(false);
      $pref::LightManager::Enable = "0";
   }
}
/*
function Tgl_10::onAction(%this)
{
   if ( %this.getValue() )
   {
      echo( "LightManager:MLAA Enabled" );
      //PostFXManager.settingsEffectSetEnabled("MLAA", true);
      MLAAPostFX.enable();
      $pref::LightManager::Enable::MLAA = "1";
   }
   else
   {
      echo( "LightManager:MLAA Disabled" );
      //PostFXManager.settingsEffectSetEnabled("MLAA", false);
      MLAAPostFX.disable();
      $pref::LightManager::Enable::MLAA = "0";
   }
   //OptionsDlg._updateApplyState();
}
*/
function Tgl_11::onAction(%this)
{
   if ( %this.getValue() )
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:HDR Enabled" );
      }
      
      HDRPostFX.enable();
      $pref::LightManager::Enable::HDR = "1";
   }
   else
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:HDR Disabled" );
      }
      
      HDRPostFX.disable();
      $pref::LightManager::Enable::HDR = "0";
   }
}

function Tgl_12::onAction(%this)
{
   if ( %this.getValue() )
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:SSAO Enabled" );
      }
      
      SSAO2PostFX.enable();
      $pref::LightManager::Enable::SSAO = "1";
   }
   else
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:SSAO Disabled" );
      }
      
      SSAO2PostFX.disable();
      $pref::LightManager::Enable::SSAO = "0";
   }
}

function Tgl_13::onAction(%this)
{
   if ( %this.getValue() )
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:LightRays Enabled" );
      }
      
      LightRayPostFX.enable();
      $pref::LightManager::Enable::LightRays = "1";
   }
   else
   {
      if($pref::debug::consoleSpam)
      {
         echo( "LightManager:LightRays Disabled" );
      }
      
      LightRayPostFX.disable();
      $pref::LightManager::Enable::LightRays = "0";
   }
}

//exec("scripts/gui/optionsDlg.cs")
//skin selctor code
$playerSkinlList= "base	olive	urban	desert	swamp	water	blue	red	green	yellow";
function playerSkinSelector::onWake(%this)
{
   playerSkinSelector.clear();
   if($playerSkinlList !$= "")
   {
      %n=getWordCount($playerSkinlList);
      for(%i=0;%i<%n;%i++)
      {
         %extractedRaceName=getWord($playerSkinlList,%i);
         playerSkinSelector.add(%extractedRaceName, %i);
      }
      playerSkinSelector.setSelected(0); 
   } 
}

function playerSkinSelector::applyRace() // playerSkinSelector.applyRace(); 
{
   %selectedRace = playerSkinSelector.getText();
   if(%selectedRace !$= "") 
   {
      $pref::Player::Skin=%selectedRace;
      //echo(%selectedRace); 
      
   }
}

