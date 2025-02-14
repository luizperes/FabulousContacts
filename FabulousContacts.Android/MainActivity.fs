﻿namespace FabulousContacts.Droid

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android
open System.IO
open Plugin.CurrentActivity
open Plugin.Media

[<Activity (Label = "FabulousContacts", Icon = "@drawable/icon", Theme = "@style/FabulousContactsTheme.Splash", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    let getDbPath() =
        let path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        Path.Combine(path, "Contacts.db3");

    override this.OnCreate (bundle: Bundle) =
        base.SetTheme(Resources.Style.FabulousContactsTheme)
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar
        base.OnCreate (bundle)

        CrossCurrentActivity.Current.Init(this, bundle)
        CrossMedia.Current.Initialize() |> Async.AwaitTask |> ignore 

        Xamarin.Essentials.Platform.Init(this, bundle)

        Xamarin.Forms.Forms.Init (this, bundle)
        Xamarin.FormsMaps.Init (this, bundle)

        let dbPath = getDbPath()
        let appcore  = new FabulousContacts.App(dbPath)
        this.LoadApplication (appcore)

    override this.OnRequestPermissionsResult(requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults)

        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
