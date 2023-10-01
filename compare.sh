import * as vscode from "vscode";
import Timer from "./Timer";
import { exec } from 'child_process';

const lastcommitconfig = vscode.workspace.getConfiguration("lastcommit");
let timer: Timer;
let lastHead: string | null = null;

export async function activate(context: vscode.ExtensionContext) {
  timer = new Timer();
  timer.startTimer();
  vscode.window.showInformationMessage("TimeSince timer has been started!");



  const statusBarItem = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Right);
  statusBarItem.text = "𝜟=0 (+0/-0)"; // Replace with your initial text
  statusBarItem.show();

  setInterval(() => {
    exec('./output.sh', (error, stdout, stderr) => {
      if (error) {
        // Handle errors
        console.error(error);
      } else {
        // Process the script's output and update statusBarItem.text
        const scriptOutput = stdout.trim(); // Assuming the script outputs the desired text
        statusBarItem.text = scriptOutput;
      }
    });
  }, 30000);


  // Register a command to reset the timer
  let resetTimer = vscode.commands.registerCommand("lastcommit.resetTimer", () => {
    timer.resetTimer();
    vscode.window.showInformationMessage("TimeSince timer has been reset manually!");
  });

  context.subscriptions.push(resetTimer);

  // Initialize Git commit event listener after a short delay
  vscode.window.showInformationMessage("Initializing Git commit event listener...");
  setTimeout(initializeGitCommitListener, 5000); // Delay by 5 seconds
}

async function initializeGitCommitListener() {
  const gitExtension = vscode.extensions.getExtension("vscode.git");
  if (!gitExtension) {
    vscode.window.showInformationMessage("Git extension not available.");
    return;
  }

  const git = gitExtension.exports.getAPI(1);

  if (!git) {
    vscode.window.showInformationMessage("Git API not available.");
    return;
  }

  vscode.window.showInformationMessage("Git extension and API successfully initialized.");

  // Initialize lastHead
  const repos = git.repositories;
  if (repos.length > 0) {
    const repo = repos[0];
    lastHead = repo.state.HEAD?.commit;
    vscode.window.showInformationMessage(`Initial HEAD commit hash: ${lastHead}`);
  }

  // Subscribe to repository change events
  git.a.onDidChangeRepository(async (repo: any) => {
    const newHead = repo.state.HEAD?.commit;
    vscode.window.showInformationMessage(`New HEAD commit hash detected: ${newHead}`);

    if (newHead !== lastHead) {
      timer.resetTimer();
      vscode.window.showInformationMessage("TimeSince timer has been reset due to a Git commit.");
      lastHead = newHead;
    } else {
      vscode.window.showInformationMessage("HEAD commit hash unchanged; timer not reset.");
    }
  });
}

export function deactivate() { }
