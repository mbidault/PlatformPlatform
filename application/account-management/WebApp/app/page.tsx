import { Trans } from "@lingui/macro";
import { useLingui } from "@lingui/react";
import heroDesktop from "./hero-desktop.png";
import heroMobile from "./hero-mobile.png";
import { Link } from "@/lib/router/router";
import AcmeLogo from "@/ui/AcmeLogo";

export default function LandingPage() {
  const { i18n } = useLingui();
  return (
    <main className="flex min-h-screen flex-col">
      <div className="flex h-20 shrink-0 items-end bg-black dark:bg-white p-4 md:h-52">
        <AcmeLogo />
      </div>
      <div className="flex grow flex-col gap-4 md:flex-row">
        <div className="flex flex-col justify-center gap-6 md:w-2/5 md:px-20 p-6">
          <p
            className="text-xl text-neutral-800 md:text-3xl md:leading-normal"
          >
            <strong><Trans>Welcome to Acme.</Trans></strong> <Trans>This is the example for the
              {" "}
              <a href="https://platformplatform.net/" className="text-neutral-800 font-semibold mx-2">
                Acme
              </a>
              {" "}
              demo product, brought to you by PlatformPlatform
            </Trans>
          </p>
          <Link
            to="/login"
            className="flex items-center gap-5 self-start rounded bg-black px-6 py-3 text-sm font-medium text-white transition-colors hover:bg-neutral-800 md:text-base"
          >
            <Trans>Sign in</Trans>
          </Link>
        </div>
        <div className="flex items-center justify-center p-6 bg-gray-50 md:w-3/5 md:px-28 md:py-12">
          <img
            src={heroMobile}
            width={560}
            height={620}
            className="block md:hidden"
            alt={i18n.t("Screenshots of the dashboard project showing mobile versions")}
          />
          <img
            src={heroDesktop}
            width={1000}
            height={760}
            className="hidden md:block"
            alt={i18n.t("Screenshots of the dashboard project showing desktop and mobile versions")}
          />
        </div>
      </div>
    </main>
  );
}
