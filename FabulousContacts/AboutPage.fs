﻿namespace FabulousContacts

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Essentials
open FabulousContacts.Controls
open Style

module AboutPage =
    let fabulousContactsRepositoryUrl = "https://github.com/TimLariviere/FabulousContacts"
    let fsharpOrgUrl = "https://fsharp.org"
    let fabulousXamarinFormsUrl = "https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms"
    let freepikUrl = "https://www.flaticon.com/authors/freepik"
    let xamarinEssentialsUrl = "https://github.com/xamarin/Essentials"
    let authorBlogUrl = "https://timothelariviere.com"
    let authorGitHubUrl = "https://github.com/TimLariviere"
    let authorGitHubHandle = "TimLariviere"
    let authorTwitterUrl = "https://twitter.com/Tim_Lariviere"
    let authorTwitterHandle = "@Tim_Lariviere"
    let authorSlackUrl = "https://fsharp.org/guides/slack/"
    let authorSlackHandle = "@Timothé Larivière"
    
    let logo =
        View.StackLayout(heightRequest=100.,
                         widthRequest=100.,
                         horizontalOptions=LayoutOptions.Center,
                         backgroundColor=accentColor,
                         padding=15.,
                         children=[
            View.Image(source="icon.png")
        ])
        
    let aboutFabulousContacts openBrowserOnTap =
        View.StackLayout([
            View.Label(text = Strings.AboutPage_AboutFabulousContacts_NameAndVersion,
                       fontAttributes = FontAttributes.Bold,
                       horizontalOptions = LayoutOptions.Center)
            View.Label(text = Strings.AboutPage_AboutFabulousContacts_DescriptionTitle,
                       fontAttributes = FontAttributes.Bold,
                       margin = Thickness(0., 20., 0., 0.))
            View.Label(text = Strings.AboutPage_AboutFabulousContacts_Description)
            View.UnderlinedLabel(text = fabulousContactsRepositoryUrl,
                                 gestureRecognizers = [
                                     openBrowserOnTap fabulousContactsRepositoryUrl
                                 ])
        ])
        
    let aboutFSharp openBrowserOnTap =
        View.StackLayout(horizontalOptions = LayoutOptions.Center,
                         orientation = StackOrientation.Horizontal,
                         spacing = 30.,
                         children = [
            View.Label(text = Strings.AboutPage_AboutFSharp_MadeWith)
            View.StackLayout(
                gestureRecognizers = [
                    openBrowserOnTap fsharpOrgUrl
                ],
                children = [
                    View.Image(source = "fsharp.png",
                               heightRequest = 50.,
                               widthRequest = 50.)
                    View.Label(text = Strings.AboutPage_AboutFSharp_FSharp,
                               horizontalTextAlignment = TextAlignment.Center)
                ]
            )
            View.StackLayout(
                gestureRecognizers = [
                    openBrowserOnTap fabulousXamarinFormsUrl
                ],
                children = [
                    View.Image(source = "xamarin.png",
                               heightRequest = 50.,
                               widthRequest = 50.)
                    View.Label(text = Strings.AboutPage_AboutFSharp_FabulousXamarinForms,
                               horizontalTextAlignment = TextAlignment.Center)
                ]
            )
        ])
        
    let credits openBrowserOnTap =
        View.StackLayout([
            View.Label(text = Strings.AboutPage_Credits_Title,
                       fontAttributes = FontAttributes.Bold,
                       margin = Thickness(0., 20., 0., 0.))
            View.UnderlinedLabel(text = Strings.AboutPage_Credits_Freepik,
                                 gestureRecognizers = [
                                     openBrowserOnTap freepikUrl
                                 ])
            View.UnderlinedLabel(text = Strings.AboutPage_Credits_XamarinEssentials,
                                 gestureRecognizers = [
                                     openBrowserOnTap xamarinEssentialsUrl
                                 ])
        ])
        
    let aboutAuthor openBrowserOnTap =
        View.StackLayout([
            View.Label(text = Strings.AboutPage_AboutAuthor_Title,
                       fontAttributes = FontAttributes.Bold,
                       margin = Thickness(0., 20., 0., 0.))
            View.Label(text = Strings.AboutPage_AboutAuthor_AuthorName)
            View.StackLayout(orientation = StackOrientation.Horizontal,
                             spacing = 15.,
                             gestureRecognizers = [
                                openBrowserOnTap authorBlogUrl
                             ],
                             children = [
                View.Image(source = "blog.png",
                           heightRequest = 35.,
                           widthRequest = 35.)
                View.UnderlinedLabel(text = authorBlogUrl,
                                     verticalOptions = LayoutOptions.Center)
            ])
            View.Label(text = Strings.AboutPage_AboutAuthor_ReachOut,
                       margin = Thickness(0., 10., 0., 0.))
            View.StackLayout(orientation = StackOrientation.Horizontal,
                             spacing = 15.,
                             gestureRecognizers = [
                                openBrowserOnTap authorGitHubUrl
                             ],
                             children = [
                View.Image(source = "github.png",
                           heightRequest = 35.,
                           widthRequest = 35.)
                View.UnderlinedLabel(text = authorGitHubHandle,
                                     verticalOptions = LayoutOptions.Center)
            ])
            View.StackLayout(horizontalOptions = LayoutOptions.Center,
                             orientation = StackOrientation.Horizontal,
                             margin = Thickness(0., 10., 0., 0.),
                             spacing = 15.,
                             children = [
                View.StackLayout(
                    gestureRecognizers = [
                        openBrowserOnTap authorTwitterUrl
                    ],
                    children = [
                        View.Image(source = "twitter.png",
                                   heightRequest = 50.,
                                   widthRequest = 50.)
                        View.Label(text = authorTwitterHandle,
                                   horizontalTextAlignment = TextAlignment.Center)
                    ]
                )
                View.StackLayout(
                    gestureRecognizers = [
                        openBrowserOnTap authorSlackUrl
                    ],
                    children = [
                        View.Image(source = "slack.png",
                                   heightRequest = 50.,
                                   widthRequest = 50.)
                        View.Label(text = authorSlackHandle,
                                   horizontalTextAlignment = TextAlignment.Center)
                    ]
                )
            ])
        ])
        
    let view () =
        dependsOn () (fun _ () ->
            // Actions
            let openBrowser url = fun () -> Browser.OpenAsync(Uri url) |> ignore
            
            // Gesture recognizers
            let openBrowserOnTap url = View.TapGestureRecognizer(command = openBrowser url)
        
            // View
            View.ContentPage(
                content = View.ScrollView(
                    content = View.StackLayout(
                        padding = Thickness(20., 10., 20., 20.),
                        children = [
                            logo
                            aboutFabulousContacts openBrowserOnTap
                            aboutFSharp openBrowserOnTap
                            credits openBrowserOnTap
                            aboutAuthor openBrowserOnTap
                        ]
                    )
                )
            )
        )